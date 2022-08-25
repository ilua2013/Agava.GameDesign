using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public class StackableObjectPresenter : MonoBehaviour
    {
        [SerializeField]
        [StackableLayer] private int _layer;
        [SerializeField] private float _yScale;

        private StackableObject _stackable;

        public StackableObject Stackable => _stackable;
        public int Layer => _layer;

        private void Awake()
        {
            _stackable = new StackableObject(transform, _layer, _yScale);
        }
    }
}