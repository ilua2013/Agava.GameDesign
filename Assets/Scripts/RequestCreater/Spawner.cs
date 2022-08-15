using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agava.IdleGame
{
    public class Spawner : MonoBehaviour
    {
        private const int MaxPoolChildren = 1;
        private const float Cooldown = 1;

        [SerializeField] private List<StackableObjectPresenter> _variants;
        [SerializeField] private RequestBox _requestBox;
        [SerializeField] private Transform _pool;
        [SerializeField] private List<Transform> _path;

        private float _currentTime;

        private void Start()
        {
            _currentTime = Cooldown;
        }

        private void Update()
        {
            if (_currentTime >= Cooldown && _pool.childCount < MaxPoolChildren)
                Spawn();

            _currentTime += Time.deltaTime;
        }

        private void Spawn()
        {
            _currentTime = 0;
            RequestBox tempBox = Instantiate(_requestBox, _pool);
            tempBox.transform.position = _path[0].position;
            tempBox.RequestReached += ClearPool;
            tempBox.GenerateRequest(_path, _variants[Random.Range(0, _variants.Count)]);
        }

        private void ClearPool(RequestBox requestBox)
        {
            requestBox.RequestReached -= ClearPool;
        }
    }
}
