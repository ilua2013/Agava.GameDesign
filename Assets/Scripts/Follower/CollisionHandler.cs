using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunnerMovementSystem;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private MovementSystem _movementSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BoostRing boostRing))
        {
            boostRing.Disable();
            _movementSystem.BoostSpeed();
        }

        if (other.TryGetComponent(out DiminutiveRing diminutiveRing))
        {
            diminutiveRing.Disable();
            _movementSystem.DiminutiveSpeed();
        }
    }
}
