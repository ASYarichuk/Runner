using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private int _maxHeight;
    [SerializeField] private int _minHeight;
    [SerializeField] private int _stepSize;

    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if(_targetPosition.y + _stepSize < _maxHeight)
        {
            _targetPosition.y += _stepSize;
        }
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y - _stepSize > _minHeight)
        {
            _targetPosition.y -= _stepSize;
        }
    }
}
