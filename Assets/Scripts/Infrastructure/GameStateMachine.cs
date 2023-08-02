using System;
using System.Collections.Generic;

public class GameStateMachine
{
    private readonly Dictionary<Type,IGameState> _gameStatesDictionary;
    private IGameState _currentState;
    public GameStateMachine(AllServices allServices)
    {
        _gameStatesDictionary=new Dictionary<Type, IGameState>
        {
           [typeof(BootstrapState)]=new BootstrapState(this,allServices),
           [typeof(LoadInfoState)]=new LoadInfoState()
        };
    }

    public void Enter<TState>() where TState : IGameState
    {
        _currentState?.Exit();
        IGameState nextState = _gameStatesDictionary[typeof(TState)];
        _currentState = nextState;
        _currentState.Enter();
    }
    
    
}