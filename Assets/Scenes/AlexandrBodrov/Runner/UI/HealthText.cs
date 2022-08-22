using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private RunnerPlayer _player;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private UIImageAnimator _flashAnimator;

    [SerializeField] private Image _shildIcon;
    [SerializeField] private Image _heartIcon;
    [SerializeField] private Image _halfHeartIcon;

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
        if (value < 3)
        {
            _flashAnimator.TriggerSize();
        }

        if (value == 3)
        {
            _shildIcon.gameObject.SetActive(true);
            _heartIcon.gameObject.SetActive(true);
            _halfHeartIcon.gameObject.SetActive(true);
        }
        else if (value == 2)
        {
            _shildIcon.gameObject.SetActive(false);
            _heartIcon.gameObject.SetActive(true);
            _halfHeartIcon.gameObject.SetActive(true);
        }
        else if (value == 1)
        {
            _shildIcon.gameObject.SetActive(false);
            _heartIcon.gameObject.SetActive(false);
            _halfHeartIcon.gameObject.SetActive(true);
        }
        else if (value == 0)
        {
            _shildIcon.gameObject.SetActive(false);
            _heartIcon.gameObject.SetActive(false);
            _halfHeartIcon.gameObject.SetActive(false);
        }

        //_text.text = value.ToString();
    }
}