using System;
using System.Collections.Generic;

public class GameStateMachine
{
    private Dictionary<Type,IGameState> _gameStates=new Dictionary<Type, IGameState>();
    private IGameState _currentState;
    public GameStateMachine()
    {
        
    }

    public void Enter<TState>() where TState : IGameState
    {
        _currentState?.Exit();
        IGameState nextState = _gameStates[typeof(TState)];

    }
    
    
}

public interface IGameState
{
    void Enter();
    void Exit();
}