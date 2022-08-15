using Agava.IdleGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCurrency : MonoBehaviour
{
    [SerializeField] private SoftCurrencyHolder _currencyHolder;

    private void Start()
    {
        _currencyHolder.Add(20);
    }
}
