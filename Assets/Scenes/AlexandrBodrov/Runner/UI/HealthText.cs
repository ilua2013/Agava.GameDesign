using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private RunnerPlayer _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _player.HealthChanged += Display;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= Display;
    }

    private void Start()
    {
        Display(_player.Health);
    }

    private void Display(int value)
    {
        _text.text = value.ToString();
    }
}