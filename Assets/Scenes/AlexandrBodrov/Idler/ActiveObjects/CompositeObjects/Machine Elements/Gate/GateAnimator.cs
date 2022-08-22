using UnityEngine;

public class GateAnimator : MonoBehaviour
{
    [SerializeField] private ItemMachine _itemMachine;

    [Space]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _isOpenKey = "IsOpen";

    private void OnEnable()
    {
        _itemMachine.ProcessingStarted += () => SetBoolAnimator(false);
        _itemMachine.ProcessingFinished += () => SetBoolAnimator(true);
    }

    private void OnDisable()
    {
        _itemMachine.ProcessingStarted -= () => SetBoolAnimator(false);
        _itemMachine.ProcessingFinished -= () => SetBoolAnimator(true);
    }

    private void Start()
    {
        SetBoolAnimator(true);
    }

    public void SetBoolAnimator(bool value)
    {
        _animator.SetBool(_isOpenKey, value);
    }
}