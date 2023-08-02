using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly Dictionary<Type,IGameState> _gameStatesDictionary;
        private IGameState _currentState;
        public GameStateMachine(AllServices allServices,ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _gameStatesDictionary=new Dictionary<Type, IGameState>
            {
                [typeof(BootstrapState)]=new BootstrapState(this,allServices,_coroutineRunner),
                [typeof(LoadInfoState)]=new LoadInfoState(this,allServices.Single<SceneLoader>(),allServices.Single<UiGameFactory>())
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
}