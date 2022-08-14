using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MakeObstacleTransparent : MonoBehaviour
{
    [SerializeField]private ObstacleCollisionHandler _obstacleCollisionHandler;
    [SerializeField] private List<MeshRenderer> _meshReneders;
    [SerializeField] private List<Material> _transparentMaterials;
    [SerializeField] private List<Material> _defaultMaterials;
    
    private const float TransparentDuration=0.8f;
    private const float TargetAlphaValue=0.2f;

    private void OnEnable()
    {
        _obstacleCollisionHandler.Entered += OnRobotEntered;
        _obstacleCollisionHandler.Exit += OnRobotExit;
    }

    private void OnDisable()
    {
        _obstacleCollisionHandler.Entered -= OnRobotEntered;
        _obstacleCollisionHandler.Exit -= OnRobotExit;
    }
    
    public void OnRobotEntered()
    {
        for (int i = 0; i < _meshReneders.Count; i++)
        {
            _meshReneders[i].material = _transparentMaterials[i];
            var tempColor = _meshReneders[i].material.color;
            var targetColor=new Color( tempColor.r,tempColor.g,tempColor.b,TargetAlphaValue);
            _meshReneders[i].material.DOColor(targetColor, TransparentDuration);
        }
    }

    public void OnRobotExit()
    {
        for (int i = 0; i < _meshReneders.Count; i++)
            _meshReneders[i].material = _defaultMaterials[i];
    }
}
