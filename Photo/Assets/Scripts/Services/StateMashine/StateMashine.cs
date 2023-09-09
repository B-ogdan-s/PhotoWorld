using System;
using System.Collections.Generic;

public class StateMashine<StateType> where StateType : EntityState
{

    private Dictionary<Type, StateType> _states = new Dictionary<Type, StateType>();
    private StateType _state;
    public StateType State => _state;

    public StateMashine(StateType[] states)
    {
        foreach(var state in states)
        {
            state.OnChengeState += ChangeState;
            _states.Add(state.GetType(), state);
        }

    }

    public void ChangeState(Type type)
    {
        StateType newState = _states[type];

        if (newState == null || newState == _state)
            return;

        _state?.Exit();
        _state = newState;
        _state?.Enter();
    }
}
