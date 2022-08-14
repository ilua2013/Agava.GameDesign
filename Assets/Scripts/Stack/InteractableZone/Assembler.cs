using Agava.IdleGame;
using Agava.IdleGame.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : MonoBehaviour
{
    [SerializeField] private float _duration = 1;
    [SerializeField] private StackableObjectPresenter _createbleTemplate;
    [SerializeField] private StackableObjectPresenter[] _requiredTemplates;
    [SerializeField] private StackPresenter _takeFrom;
    [SerializeField] private StackPresenter _putIn;

    private bool _isAssembling = false;

    private void OnEnable()
    {
        _takeFrom.Added += Assemble;
    }

    private void OnDisable()
    {
        _takeFrom.Added -= Assemble;
    }

    private void Assemble(StackableObject stackable)
    {
        //Debug.Log(_isAssembling + " " + CanAssemble());
        if (!_isAssembling && CanAssemble())
            StartCoroutine(AssembleWithDelay());
    }

    private IEnumerator AssembleWithDelay()
    {
        _isAssembling = true;
        yield return new WaitForSeconds(_duration);

        foreach (var template in _requiredTemplates)
        {
            _takeFrom.RemoveByLayer(template.Layer);
        }

        var inst = Instantiate(_createbleTemplate, transform.position, Quaternion.identity);
        _putIn.AddToStack(inst.Stackable);

        _isAssembling = false;

        if (CanAssemble())
            StartCoroutine(AssembleWithDelay());
    }

    private bool CanAssemble()
    {
        bool canRemoveFromStack = true;
        foreach (var template in _requiredTemplates)
        {
            if (!_takeFrom.CanRemoveFromStack(template.Layer))
            {
                canRemoveFromStack = false;
            }
        }

        return canRemoveFromStack;
    }
}
