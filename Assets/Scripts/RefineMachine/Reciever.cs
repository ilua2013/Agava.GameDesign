using System;
using UnityEngine;

namespace Agava.IdleGame
{
    public class Reciever : StackInteractableZone
    {
        [SerializeField] private StackPresenter _selfStack;
        [SerializeField] private RefineMachine _refineMachine;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            if (enteredStack.Count == 0)
                return false;

            foreach (var item in enteredStack.Data)
                if (_selfStack.CanAddToStack(item.Layer) && _refineMachine.IsBusy == false)
                    return true;

            return false;
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            int index = 0;
            foreach (var item in enteredStack.Data)
            {
                if (_selfStack.CanAddToStack(item.Layer))
                    break;

                index++;
            }

            if (index >= enteredStack.Count)
                throw new InvalidOperationException();

            var stackable = enteredStack.RemoveAt(index);
            _selfStack.AddToStack(stackable);
        }
    }
}
