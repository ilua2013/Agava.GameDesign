using System;
using UnityEngine;
using Agava.IdleGame.Model;
using DG.Tweening;
using Agava.IdleGame;

public class SaleZone : StackInteractableZone
{
    [SerializeField] private StackableLayerMask _layers;
    [SerializeField] private SoftCurrencyHolder _currencyHolder;
    [SerializeField] private int _addValue = 10;

    protected override bool CanInteract(StackPresenter enteredStack)
    {
        foreach (var item in enteredStack.Data)
            if (_layers.ContainsLayer(item.Layer))
                return true;

        return false;
    }

    protected override void InteractAction(StackPresenter enteredStack)
    {
        StackableObject removedObject = null;
        foreach (var item in enteredStack.Data)
        {
            if (_layers.ContainsLayer(item.Layer))
            {
                removedObject = item;
                break;
            }
        }

        if (removedObject == null)
            throw new InvalidOperationException("Can't remove object from stack");
        _currencyHolder.Add(_addValue);
        enteredStack.RemoveFromStack(removedObject);
        removedObject.View.DOMove(transform.position, 1f).OnComplete(() => Destroy(removedObject.View.gameObject));
    }
}
