using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public class StackableObjectPresenter : MonoBehaviour
    {
        [SerializeField]
        [StackableLayer] private int _layer;

        private StackableObject _stackable;

        public StackableObject Stackable => _stackable;
        public int Layer => _layer;

        private void Awake()
        {
            _stackable = new StackableObject(transform, _layer);
        }

        public StackableObject GetStackable()
        {
            if(_stackable == null)
            {
                _stackable = new StackableObject(transform, _layer);
            }

            return _stackable;
        }
    }
}