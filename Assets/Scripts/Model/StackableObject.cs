using UnityEngine;

namespace Agava.IdleGame.Model
{
    public class StackableObject
    {
        [SerializeField] private float _yScale;

        public readonly Transform View;
        public readonly int Layer;

        public float YScale => _yScale;

        public StackableObject(Transform view, int layer, float yScale)
        {
            _yScale = yScale;
            View = view;
            Layer = layer;
        }
    }
}