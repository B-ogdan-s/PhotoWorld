using UnityEngine;
public class PlayerIdelState : PlayerState
{
    public PlayerIdelState(PlayerComponentData playerComponentData) : base(playerComponentData)
    {
    }

    public override void Enter()
    {
        Debug.Log("Idel");
    }

    public override void StartMove()
    {
        OnChengeState?.Invoke(typeof(PlayerMoveState));
    }
}
