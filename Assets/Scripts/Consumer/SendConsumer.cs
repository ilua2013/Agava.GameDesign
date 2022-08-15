using Agava.IdleGame.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agava.IdleGame
{
    public class SendConsumer : StackInteractableZone
    {
        [SerializeField] private StackPresenter _stackPresenter;

        private List<StackableObject> _presenters;

        private void Start()
        {
            _presenters = new List<StackableObject>();
            _stackPresenter.Added += SetStackableObject;
        }

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            if (_presenters.Count > 0)
                return enteredStack.CanAddToStack(_presenters[0].Layer);

            return false;
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            enteredStack.AddToStack(_stackPresenter.RemoveAt(0));
            _presenters.RemoveAt(0);
        }

        private void SetStackableObject(StackableObject template)
        {
            _presenters.Add(template);
        }
    }
}
