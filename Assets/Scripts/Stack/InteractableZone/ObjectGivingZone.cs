using System;
using UnityEngine;

namespace Agava.IdleGame
{
    public class ObjectGivingZone : StackInteractableZone
    {
        [SerializeField] private StackPresenter _selfStack;
        [SerializeField] private StackableObjectPresenter _template;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            if (_selfStack.Count == 0)
                return false;

            return true;
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            if (_selfStack.Count <= 0)
                return;

            if (enteredStack.CanAddToStack(_selfStack.GetFirst().Layer))
            {
                var inst = Instantiate(_template, transform.position, _template.transform.rotation);
                enteredStack.AddToStack(inst.Stackable);
                _selfStack.RemoveFromStack(_selfStack.GetFirst());
            }

        }

        //protected override void InteractAction(StackPresenter enteredStack)
        //{
        //    if (_selfStack.Count <= 0)
        //        return;

        //    if (enteredStack.CanAddToStack(_selfStack._stackableTypes.Value))
        //    {
        //        var inst = Instantiate();
        //        enteredStack.AddToStack(_selfStack._stackableTypes.Value);
        //    }

        //    _selfStack.RemoveFromStack(_selfStack._stackableTypes.Value);
        //}
    }
}