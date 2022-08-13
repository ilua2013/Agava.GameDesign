using System.Collections.Generic;
using UnityEngine;

namespace Agava.IdleGame.Examples
{
    [RequireComponent(typeof(Rigidbody))]
    public class BodyMovement : MonoBehaviour
    {
        [SerializeField] private List<PlayerInput> _inputs;
        [SerializeField][Min(0)] private float _speed = 0.2f;

        private Rigidbody _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var rawDirection = Vector3.zero;

            foreach (var input in _inputs)
            {
                var direction = input.Direction;
                if (direction != Vector2.zero)
                {
                    rawDirection = new Vector3(direction.x, 0, direction.y);
                    break;
                }
            }

            _body.velocity = rawDirection * _speed + Vector3.up * _body.velocity.y;
            transform.LookAt(transform.position + rawDirection);
        }
    }
}