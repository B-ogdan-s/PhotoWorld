using System;
public abstract class EntityState
{
    public Action<Type> OnChengeState;

    public virtual void Enter() { }
    public virtual void Exit() { }

    public virtual void Update() { }
    public virtual void Fixedupdate() { }
}
