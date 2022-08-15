using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wallet wallet))
        {
            wallet.AddCoin();
            gameObject.SetActive(false);
        }
    }
}