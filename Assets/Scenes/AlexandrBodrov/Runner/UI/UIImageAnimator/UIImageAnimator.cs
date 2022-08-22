using UnityEngine;

public class UIImageAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerKey = "Ripple";

    //[Space]
    //[SerializeField] private RectTransform _transform;
    //[SerializeField][Min(0)] private Vector2 _startSize = new(80, 80);
    //[SerializeField][Min(0)] private Vector2 _addSize = new(5, 5);
    //[SerializeField][Min(0)] private Vector2 _recoveryPower = new(10, 10);

    private Vector2 _size;

    //private void Start()
    //{
    //    SetSize(_startSize);
    //}

    //private void Update()
    //{
    //    if (_size.x > _startSize.x || _size.y > _startSize.y)
    //    {
    //        var difference = _size - _startSize;
    //        var speed = _recoveryPower * difference;
    //        var step = speed * Time.deltaTime;

    //        SetSize(_size - step);
    //    }
    //}

    public void TriggerSize()
    {
        //SetSize(_size + _addSize);
        ActivateAnimationTrigger();
    }

    private void ActivateAnimationTrigger()
    {
        _animator.SetTrigger(_triggerKey);
    }

    //private void SetSize(Vector2 size)
    //{
    //    _size = size;
    //    Debug.Log($"Size: {_size}");
    //    _transform.sizeDelta = _size;
    //}
}