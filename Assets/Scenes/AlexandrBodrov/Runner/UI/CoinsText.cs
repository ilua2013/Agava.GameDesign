using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private UIImageAnimator _imageAnimator;

    private void OnEnable()
    {
        _wallet.CoinsChanged += Display;
    }

    private void OnDisable()
    {
        _wallet.CoinsChanged -= Display;
    }

    private void Start()
    {
        Display(_wallet.Coins);
    }

    private void Display(int value)
    {
        _text.text = value.ToString();
        _imageAnimator.TriggerSize();
    }
}