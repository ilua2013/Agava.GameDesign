using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using Agava.IdleGame.Model;
using System.Collections;

namespace Agava.IdleGame
{
    public abstract class StackView : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private float _animationDuration = 0.15f;
        [Header("Add Settings")]
        [SerializeField] private FloatSetting _scalePunch = new FloatSetting(true, 1.1f);
        [SerializeField] private FloatSetting _jumpPower = new FloatSetting(false, 0f);
        [SerializeField] private Vector3 _rotateObject;

        protected List<StackableObject> _stackables = new List<StackableObject>();

        public void Add(StackableObject stackable, UnityAction onComplete)
        {
            Vector3 endPosition = CalculateAddEndPosition(_container, stackable);
            Vector3 endRotation = CalculateEndRotation(_container, stackable.View);
            Vector3 defaultScale = stackable.View.localScale;

            stackable.View.DOComplete(true);
            stackable.View.parent = _container;

            stackable.View.DOLocalMove(endPosition, _animationDuration).OnComplete(() => onComplete?.Invoke());

            if(_rotateObject != Vector3.zero)
            {
                endRotation = _rotateObject;
            }

            stackable.View.DOLocalRotate(endRotation, _animationDuration);

            if (_scalePunch.Enabled)
            {
                StartCoroutine(Animation(stackable, defaultScale));
            }
                //stackable.View.DOPunchScale(defaultScale * _scalePunch.Value, _animationDuration);
            if (_jumpPower.Enabled)
                stackable.View.DOLocalJump(endPosition, _jumpPower.Value, 1, _animationDuration);

            _stackables.Add(stackable);
        }

        private IEnumerator Animation(StackableObject anim, Vector3 defaultScale)
        {
            anim.View.DOScale(defaultScale * _scalePunch.Value, _animationDuration / 2);
            yield return new WaitForSeconds(_animationDuration / 2f);
            anim.View.DOScale(defaultScale, _animationDuration / 2);
        }

        public void Remove(StackableObject stackable)
        {
            stackable.View.DOComplete(true);
            stackable.View.parent = null;

            _stackables.Remove(stackable);
            Sort(_stackables, _animationDuration);
        }

        protected virtual Vector3 CalculateEndRotation(Transform container, Transform stackable) { return Vector3.zero; }
        protected abstract Vector3 CalculateAddEndPosition(Transform container, StackableObject stackable);
        protected abstract void Sort(IEnumerable<StackableObject> unsortedTransforms, float animationDuration);

        #region InspectorSettings
        [Serializable]
        public class Setting<T>
        {
            [SerializeField] private bool _enabled;
            [SerializeField] private T _value;

            public Setting(bool enabled, T value)
            {
                _enabled = enabled;
                _value = value;
            }

            public bool Enabled => _enabled;
            public T Value => _value;
        }

        [Serializable]
        public class FloatSetting : Setting<float>
        {
            public FloatSetting(bool enabled, float value)
            : base(enabled, value) { }
        }

        [Serializable]
        public class VectorSetting : Setting<Vector3>
        {
            public VectorSetting(bool enabled, Vector3 value)
            : base(enabled, value) { }
        }
        #endregion
    }
}