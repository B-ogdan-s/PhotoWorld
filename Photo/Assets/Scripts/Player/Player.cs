using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PhotoCamera _photoCamera;
    [SerializeField] private PlayerComponentData _playerComponentData;
    private StateMashine<PlayerState> _stateMashine;


    private void Awake()
    {
        SerializeInputSystem();
        SerializeStateMachine();

    }

    private void Update()
    {
        _playerComponentData.PlayerMove.UpdateRot();
        _stateMashine.State.Update();
    }
    private void FixedUpdate()
    {
        _stateMashine.State.Fixedupdate();
    }

    private void StartMove()
    {
        _stateMashine.State.StartMove();
    }
    private void StopMove()
    {
        _stateMashine.State.StopMove();
    }

    private void SerializeInputSystem()
    {
        _playerInput.OnStartMove += StartMove;
        _playerInput.OnStopMove += StopMove;
        _playerInput.OnSetMoveDirection += _playerComponentData.PlayerMove.SetDirection;

        _playerInput.OnJump += _playerComponentData.PlayerJump.Jump;

        _playerInput.OnOpenCamera += _photoCamera.OpenOrClosePhotoCamera;
    }
    private void SerializeStateMachine()
    {
        PlayerState[] states = new PlayerState[]
        {
            new PlayerIdelState(_playerComponentData),
            new PlayerMoveState(_playerComponentData)
        };
        _stateMashine = new StateMashine<PlayerState>(states);
        _stateMashine.ChangeState(typeof(PlayerIdelState));
    }
}
