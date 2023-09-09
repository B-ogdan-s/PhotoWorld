using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerComponentData playerComponentData) : base(playerComponentData)
    {
    }

    public override void Fixedupdate()
    {
        _componentData.PlayerMove.Move();
    }

    public override void StopMove()
    {
        OnChengeState?.Invoke(typeof(PlayerIdelState));
    }
}

