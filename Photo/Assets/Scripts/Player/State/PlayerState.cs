
public abstract class PlayerState : EntityState
{
    protected PlayerComponentData _componentData;

    public PlayerState(PlayerComponentData playerComponentData)
    {
        _componentData = playerComponentData;
    }

    public virtual void StartMove() { }
    public virtual void StopMove() { }
}
