using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.IdleGame.Model;
using System;

namespace Agava.IdleGame
{
    public class RequestBox : MonoBehaviour
    {
        [SerializeField] private StackPresenter _stackPresenter;
        [SerializeField] private RequestBubble _requestBubble;
        [SerializeField] private float _speed;

        private int _needStackableObjectCount;
        private int _currentStackableObjectCount;
        private List<Transform> _path;
        private StackableObjectPresenter _requestVariant;
        private bool _isRequestComplete;
        private Coroutine _coroutine;

        public event Action<RequestBox> RequestReached;

        public void GenerateRequest(List<Transform> path, StackableObjectPresenter variant)
        {
            _stackPresenter.SetStackableTypes(variant.Layer + 2);
            _stackPresenter.Added += ChangeCount;
            _needStackableObjectCount = UnityEngine.Random.Range(1, 4);
            _path = path;
            _requestVariant = variant;
            _isRequestComplete = false;
            PrepairMove();
        }

        private void ChangeCount(StackableObject stackable)
        {
            _currentStackableObjectCount++;

            if (_currentStackableObjectCount >= _needStackableObjectCount)
            {
                _stackPresenter.Added -= ChangeCount;
                _isRequestComplete = true;
                RequestReached?.Invoke(this);
                transform.parent = null;
            }

            _requestBubble.ChangeCount(_needStackableObjectCount - _currentStackableObjectCount);
        }

        private void PrepairMove()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            int pointIndex = 1;

            while (transform.position != _path[pointIndex].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _path[pointIndex].position, _speed * Time.deltaTime);

                if (transform.position == _path[pointIndex].position)
                {
                    if (_isRequestComplete == false)
                    {
                        _requestBubble.gameObject.SetActive(true);
                        _requestBubble.SetRequest(_needStackableObjectCount, _requestVariant.Layer);
                    }

                    while (_isRequestComplete == false)
                        yield return null;

                    _requestBubble.gameObject.SetActive(false);

                    if (++pointIndex >= _path.Count)
                        Destroy(gameObject);
                }

                yield return null;
            }
        }
    }
}
