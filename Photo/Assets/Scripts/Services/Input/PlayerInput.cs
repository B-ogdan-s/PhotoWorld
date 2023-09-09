using System;
using UnityEngine;

[Serializable]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMoveKeyInfo[] _moveKeyList;
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private KeyCode _cameraKey;

    private Vector2 _direction;

    public Action<Vector3> OnSetMoveDirection;
    public Action OnStartMove;
    public Action OnStopMove;
    public Action OnJump;
    public Action OnOpenCamera;


    public Vector2 Direction
    {
        get => _direction;
        private set
        {
            if (value != _direction)
            {
                if(value == Vector2.zero)
                    OnStopMove?.Invoke();
                else
                    OnStartMove?.Invoke();

                _direction = value;
                OnSetMoveDirection?.Invoke(new Vector3(_direction.x, 0, _direction.y));
            }
        }
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        GetMoveDirection();
        CheckDownKey(_jumpKey, OnJump);
        CheckDownKey(_cameraKey, OnOpenCamera);
    }
    
    private void GetMoveDirection()
    {
        Vector2 direction = Vector2.zero;

        foreach(PlayerMoveKeyInfo moveKey in _moveKeyList)
        {
            if(Input.GetKey(moveKey.Key))
            {
                direction += moveKey.Direction;
            }
        }

        Direction = direction.normalized;
    }

    private void CheckDownKey(KeyCode keyCode, Action action)
    {
        if(Input.GetKeyDown(keyCode))
        {
            action?.Invoke();
        }
    }

    [Serializable]
    private class PlayerMoveKeyInfo
    {
        [SerializeField] private KeyCode _key;
        [SerializeField] private Vector2Int _direction;

        public KeyCode Key => _key;
        public Vector2Int Direction => _direction;
    }
}
