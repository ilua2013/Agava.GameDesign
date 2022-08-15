using TMPro;
using UnityEngine;

public class CircleTimer : MonoBehaviour
{
    private const int MinuteValue = 60;
    [SerializeField] private TMP_Text _currentTimeText;

    private float _currentTime;

    private void Start()
    {
        _currentTime = 0;
        UpdateInfo();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        UpdateInfo();
    }

    public string GetResult()
    {
        return _currentTimeText.text;
    }

    private void UpdateInfo()
    {
        int minutes = (int)_currentTime / MinuteValue;
        int seconds = (int)_currentTime % MinuteValue;

        _currentTimeText.text = $"{minutes} : {seconds}";
    }
}
