using Agava.IdleGame;
using Agava.IdleGame.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private float _duration = 1;
    [SerializeField] private StackableObjectPresenter _createbleTemplate;
    [SerializeField] private StackableObjectPresenter _requiredTemplate;
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
        if(!_isAssembling)
            StartCoroutine(AssembleWithDelay());
    }

    private IEnumerator AssembleWithDelay()
    {
        _isAssembling = true;
        yield return new WaitForSeconds(_duration);
        _takeFrom.RemoveAt(0);
        var inst = Instantiate(_createbleTemplate, transform.position, Quaternion.identity);
        _putIn.AddToStack(inst.Stackable);
        _isAssembling = false;

        if (_takeFrom.CanRemoveFromStack(_requiredTemplate.Layer))
            StartCoroutine(AssembleWithDelay());
    }
}
