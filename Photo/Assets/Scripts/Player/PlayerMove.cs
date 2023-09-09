using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed;

    private Vector3 _direction = Vector3.zero;

    public void Move()
    {
        Vector3 direction = _direction.x * _playerTransform.right + _direction.z * _playerTransform.forward;

        _controller.Move(direction * _speed * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void UpdateRot()
    {
        Vector3 rot =  Vector3.Scale(Vector3.up, _cameraTransform.localEulerAngles);
        _playerTransform.localEulerAngles = rot;
    }
}
