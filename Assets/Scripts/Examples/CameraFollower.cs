using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float SmoothingPower = 0.3f;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _target;

        private Vector3 _positionOffset;

        private void OnValidate()
        {
            _offset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            //Vector3 desiredPosition = _target.position + _positionOffset;
            //transform.position = Vector3.Lerp(transform.position, desiredPosition, 1f / SmoothingPower * Time.deltaTime);

            transform.position = _offset + _target.position;
        }
    }
}