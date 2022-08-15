using Agava.IdleGame;
using Agava.IdleGame.Model;
using System.Collections.Generic;
using UnityEngine;

public class TargetcollectorStack : MonoBehaviour
{
    [SerializeField] private StackPresenter _stackPresenter;

    public IEnumerable<StackableObject> Data => _stackPresenter.Data;
}
