using UnityEngine;

namespace Agava.IdleGame
{
    public class ObjectProducerZone : StackInteractableZone
    {
        [Header("Produced template")]
        [SerializeField] private StackableObjectPresenter _template;
        [SerializeField] private Vector3 _eulerSpawnObject = Vector3.zero;
        [SerializeField] private Vector3 _positionSpawn = Vector3.zero;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            return enteredStack.CanAddToStack(_template.Layer);
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            if (_positionSpawn == Vector3.zero)
            {
                _positionSpawn = transform.position;
            }

            var inst = Instantiate(_template, _positionSpawn, Quaternion.Euler(_eulerSpawnObject));
            enteredStack.AddToStack(inst.Stackable);
        }
    }
}