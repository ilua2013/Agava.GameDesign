using Agava.IdleGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSellZone : StackInteractableZone
{
    [SerializeField] private StackPresenter _selfStack;
    [SerializeField] private StackableObjectPresenter[] _templates;
    [SerializeField] private SoftCurrencyHolder _currency;

    protected override bool CanInteract(StackPresenter enteredStack)
    {
        if (enteredStack.Count <= 0)
            return false;

        return true;
    }

    protected override void InteractAction(StackPresenter enteredStack)
    {
        if (!CanInteract(enteredStack))
            return;

        var firstObject = enteredStack.GetFirst();
        _currency.Add(firstObject.Price);
        enteredStack.RemoveFromStack(firstObject);
        //foreach (var item in _templates)
        //{
        //    if(item.Layer == firstObject.Layer)
        //    {
        //        var inst = Instantiate(item, transform.position, Quaternion.identity);
        //        _selfStack.AddToStack(inst.Stackable);
        //        break;
        //    }
        //}
    }
}
