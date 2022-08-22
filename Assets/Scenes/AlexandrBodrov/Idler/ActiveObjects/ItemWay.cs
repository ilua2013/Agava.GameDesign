using Agava.IdleGame.Model;
using UnityEngine;
using UnityEngine.Events;

public class ItemWay
{
    public StackableObject Item { get; private set; }

    public bool IsFinished { get; private set; }

    public event UnityAction Finished;

    private Vector3 _startPoint;
    private Vector3 _finishPoint;
    private float _duration;

    private float _progress;

    public ItemWay(Vector3 startPiint, Vector3 finishPoint, float duration, StackableObject item)
    {
        _startPoint = startPiint;
        _finishPoint = finishPoint;
        _duration = duration;
        Item = item;
    }

    public void Update(float timeInterval)
    {
        if (IsFinished == false)
        {
            _progress += Time.deltaTime / _duration;
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        var position = Vector3.Lerp(_startPoint, _finishPoint, _progress);
        Item.View.position = position;

        if (_progress >= 1)
        {
            IsFinished = true;
            Finished?.Invoke();
        }
    }

}
