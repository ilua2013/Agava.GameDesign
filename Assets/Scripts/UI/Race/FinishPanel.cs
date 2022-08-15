using TMPro;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private CircleTimer _circleTimer;
    [SerializeField] private TMP_Text _text;

    public void ShowResult()
    {
        Time.timeScale = 0;
        _panel.SetActive(true);
        _text.text = $"Круг завершен, текущее время - {_circleTimer.GetResult()}";
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
