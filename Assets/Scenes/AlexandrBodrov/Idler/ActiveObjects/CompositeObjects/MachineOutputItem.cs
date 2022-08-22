using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MachineOutputItem : MonoBehaviour
{
    [SerializeField] private StackPresenter _outputStack;
    [SerializeField] private StackableObjectPresenter _outputItemPrefab;
    [SerializeField] private ItemMovement _itemMovement;
    [SerializeField][Min(0)] private int _number = 1;
    [SerializeField][Min(0)] private float _interval = 1f;

    public bool IsReady { get; private set; }

    public event UnityAction<bool> ReadinessChanged;

    private void OnEnable()
    {
        _outputStack.Removed += OnStacksChanged;
        _itemMovement.WayFinished += OnItemGived;
    }

    private void OnDisable()
    {
        _outputStack.Removed -= OnStacksChanged;
        _itemMovement.WayFinished -= OnItemGived;
    }

    private void Start()
    {
        OnStacksChanged();
    }

    public void GiveItems()
    {
        StartCoroutine(AddItems());
    }

    private void OnStacksChanged(StackableObject item = null)
    {
        IsReady = _outputStack.Count + _number + _itemMovement.Ways <= _outputStack.Capacity;
        ReadinessChanged?.Invoke(IsReady);
    }

    private void OnItemGived(StackableObject item)
    {
        _outputStack.AddToStack(item);
        OnStacksChanged();
    }

    private IEnumerator AddItems()
    {
        for (int i = 0; i < _number; i++)
        {
            yield return new WaitForSeconds(_interval);

            var item = Instantiate(_outputItemPrefab, _itemMovement.StartPoint, Quaternion.identity);
            _itemMovement.StartMovement(item.Stackable);
        }
    }
}