using Agava.IdleGame.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemMovement : MonoBehaviour
{
    [SerializeField][Min(0)] private float _duration = 1f;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _finishPoint;

    public Vector3 StartPoint => _startPoint.position;

    public int Ways => _ways.Count;

    public event UnityAction<StackableObject> WayStarted;
    public event UnityAction<StackableObject> WayFinished;

    private List<ItemWay> _ways = new();

    private void Update()
    {
        int vays = _ways.Count;
        if (vays > 0)
        {
            ItemWay removedWay = null;

            float timeInterval = Time.deltaTime;
            foreach (var way in _ways)
            {
                if (way.IsFinished == false)
                {
                    way.Update(timeInterval);
                }
                else
                {
                    removedWay = way;
                }
            }

            _ways.Remove(removedWay);
        }
    }

    public void StartMovement(StackableObject item)
    {
        var newWay = new ItemWay(_startPoint.position, _finishPoint.position, _duration, item);
        newWay.Finished += () => OnItemFinished(newWay);
        _ways.Add(newWay);

        WayStarted?.Invoke(item);
    }

    private void OnItemFinished(ItemWay way)
    {
        WayFinished?.Invoke(way.Item);
    }
}