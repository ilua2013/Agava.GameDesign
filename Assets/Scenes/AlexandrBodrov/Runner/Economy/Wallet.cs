using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public int Coins { get; private set; }

    public event UnityAction<int> CoinsChanged;

    public void AddCoin()
    {
        Coins++;
        CoinsChanged?.Invoke(Coins);
    }
}