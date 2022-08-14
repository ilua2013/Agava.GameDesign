using UnityEngine;

namespace Agava.IdleGame.Model
{
    public class StackableObject
    {
        public readonly Transform View;
        public readonly int Layer;
        public readonly int Price;

        public StackableObject(Transform view, int layer, int price)
        {
            View = view;
            Layer = layer;
            Price = price;
        }
    }
}