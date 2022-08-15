using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agava.IdleGame
{
    public class Sender : StackInteractableZone
    {
        private StackableObjectPresenter _template;

        public event Action Released;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            if (_template != null)
                return enteredStack.CanAddToStack(_template.Layer);

            return false;
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            enteredStack.AddToStack(_template.Stackable);
            _template = null;
            Released?.Invoke();
        }

        public void SetStackableObject(StackableObjectPresenter template)
        {
            _template = template;
        }
    }
}
