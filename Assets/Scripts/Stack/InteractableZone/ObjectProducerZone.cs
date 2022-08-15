using UnityEngine;

namespace Agava.IdleGame
{
    public class ObjectProducerZone : StackInteractableZone
    {
        [Header("Produced template")]
        [SerializeField] private StackableObjectPresenter _template;
        [SerializeField] private SoftCurrencyHolder _currencyHolder;
        [SerializeField] private int _cost;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            return (enteredStack.CanAddToStack(_template.Layer) && CanBuy());
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            var inst = Instantiate(_template, transform.position, Quaternion.identity);
            enteredStack.AddToStack(inst.Stackable);
            _currencyHolder.Spend(_cost);
        }

        private bool CanBuy()
        {
            return _currencyHolder.Value > _cost;
        }
    }
}