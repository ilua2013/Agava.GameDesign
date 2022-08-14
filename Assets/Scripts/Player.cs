using Agava.IdleGame;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private GameObject _model;
    [SerializeField] private SoftCurrencyHolder _softCurrencyHolder;

    public void TakeDamage()
    {
        _movementSystem.enabled = false;
        _mouseInput.enabled = false;
        _model.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            _softCurrencyHolder.Add(coin.RewardAmount);
        }
    }
}
