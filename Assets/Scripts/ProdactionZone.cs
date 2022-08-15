using System;
using UnityEngine;
using Agava.IdleGame.Model;
using DG.Tweening;
using Agava.IdleGame;

public class ProdactionZone : StackInteractableZone
{
    [SerializeField] private StackableLayerMask _layers;
    [SerializeField] private StackableObjectPresenter _template;

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
                var inst = Instantiate(_template, transform.position, Quaternion.identity);
                enteredStack.AddToStack(inst.Stackable);
                break;
            }
        }

        if (removedObject == null)
            throw new InvalidOperationException("Can't remove object from stack");
        enteredStack.RemoveFromStack(removedObject);
        removedObject.View.DOMove(transform.position, 1f).OnComplete(() => Destroy(removedObject.View.gameObject));




        //var inst = Instantiate(_template, transform.position, Quaternion.identity);
        //enteredStack.AddToStack(inst.Stackable);




    }


}
