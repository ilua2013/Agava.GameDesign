using Agava.IdleGame;
using Agava.IdleGame.Model;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MachineInputItem : MonoBehaviour
{
    [SerializeField] private StackPresenter _inputStack;
    [SerializeField] private StackableLayerMask _inputLayers;
    [SerializeField] private ItemMovement _itemMovement;
    [SerializeField][Min(0)] private int _number = 1;
    [SerializeField][Min(0)] private float _startingDelay = 0;
    [SerializeField][Min(0)] private float _interval = 1f;

    [SerializeField][Min(0)] private float _travelTime = 1f;

    public bool IsReady { get; private set; }
    public bool ItemsIsRemoved => _removedItems == _number;

    public event UnityAction<bool> ReadinessChanged;
    public event UnityAction ItemRemoved;

    private int _removedItems;

    private void OnEnable()
    {
        _inputStack.Added += OnStacksChanged;
        _itemMovement.WayFinished += OnItemTaked;
    }

    private void OnDisable()
    {
        _inputStack.Added -= OnStacksChanged;
        _itemMovement.WayFinished -= OnItemTaked;
    }

    private void Start()
    {
        OnStacksChanged();
    }

    public void TakeItems()
    {
        StartCoroutine(RemoveItems());
    }

    public void ResetItems()
    {
        _removedItems = 0;
    }

    private void OnStacksChanged(StackableObject item = null)
    {
        IsReady = _inputStack.Count >= _number;
        ReadinessChanged?.Invoke(IsReady);
    }

    private void OnItemTaked(StackableObject item)
    {
        Destroy(item.View.gameObject);
        _removedItems++;

        if (ItemsIsRemoved)
        {
            OnStacksChanged();
            ItemRemoved?.Invoke();
        }
    }

    private IEnumerator RemoveItems()
    {
        yield return new WaitForSeconds(_startingDelay);

        for (int i = 0; i < _number; i++)
        {
            StackableObject inputItem = null;
            foreach (var item in _inputStack.Data)
            {
                if (_inputLayers.ContainsLayer(item.Layer))
                {
                    inputItem = item;
                    break;
                }
            }

            _inputStack.RemoveFromStack(inputItem);
            inputItem.View.DOMove(_itemMovement.StartPoint, _travelTime).OnComplete(() =>
            {
                _itemMovement.StartMovement(inputItem);
            });

            yield return new WaitForSeconds(_interval);
        }
    }
}