using UnityEngine;

public class ManipulatorAnimator : MonoBehaviour
{
    [SerializeField] private ItemMachine _itemMachine;

    [Space]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _isWorkKey = "IsWork";

    private void OnEnable()
    {
        _itemMachine.ProcessingStarted += () => SetBoolAnimator(true);
        _itemMachine.ProcessingFinished += () => SetBoolAnimator(false);
    }

    private void OnDisable()
    {
        _itemMachine.ProcessingStarted -= () => SetBoolAnimator(true);
        _itemMachine.ProcessingFinished -= () => SetBoolAnimator(false);
    }

    public void SetBoolAnimator(bool value)
    {
        _animator.SetBool(_isWorkKey, value);
    }
}