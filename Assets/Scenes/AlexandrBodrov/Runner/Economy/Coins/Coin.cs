using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerKey = "Collect";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wallet wallet))
        {
            wallet.AddCoin();
            ActivateAnimationTrigger();
            //gameObject.SetActive(false);
        }
    }

    public void OnAnimatorCollector()
    {
        //gameObject.SetActive(false);
    }

    private void ActivateAnimationTrigger()
    {
        _animator.SetTrigger(_triggerKey);
    }
}