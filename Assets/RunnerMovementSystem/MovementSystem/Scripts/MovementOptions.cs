using System;
using UnityEngine;

namespace RunnerMovementSystem
{
    [Serializable]
    public class MovementOptions
    {
        private const float SpeedMultiplier = 1.5f;
        private const float SpeedDiminutive = 0.2f;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _borderOffset;

        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float BorderOffset => _borderOffset;

        public void BoostSpeed()
        {
            _moveSpeed *= SpeedMultiplier;
        }

        public void DiminutiveSpeed()
        {
            _moveSpeed -= _moveSpeed * SpeedDiminutive;
        }
    }
}