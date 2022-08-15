using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SoftCurrencyAnimation : MonoBehaviour
{
    private Animator _animator;
    private string _scaleAnimation = "Scale";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        _animator.SetTrigger(_scaleAnimation);
    }
}
