using Agava.IdleGame;
using Agava.IdleGame.Model;
using System.Collections.Generic;
using UnityEngine;

public class CollectorStack : MonoBehaviour
{
    [SerializeField] private PlayerStackPresenter _stackPresenter;

    private bool _isCollect = false;
    private IEnumerable<StackableObject> _stackableObjects;

    private void Update()
    {
        if (_isCollect == true)
            Collect();
    }

    private void Collect()
    {
        foreach (var stack in _stackableObjects)
            _stackPresenter.AddToStack(stack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TargetcollectorStack>(out TargetcollectorStack targetcollectorStack))
        {
            _isCollect = true;
            _stackableObjects = targetcollectorStack.Data;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<TargetcollectorStack>(out TargetcollectorStack targetcollectorStack))
        {
            _isCollect = false;
        }
    }
}
