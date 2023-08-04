using System;
using System.Collections.Generic;
using Infrastructure.Services;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IGameState> _gameStatesDictionary;
        private IGameState _currentState;
        public GameStateMachine(AllServices allServices,ICoroutineRunner coroutineRunner)
        {
            _gameStatesDictionary=new Dictionary<Type, IGameState>
            {
                [typeof(BootstrapState)]=new BootstrapState(this,allServices,coroutineRunner),
                [typeof(LoadInfoState)]=new LoadInfoState(this,allServices.Single<SceneLoader>(),allServices.Single<UiGameFactory>(),allServices.Single<WorldData>()),
                [typeof(GameLoadInfoState)]=new GameLoadInfoState(this,allServices.Single<GameFactory>(),allServices.Single<UiGameFactory>(),allServices.Single<WorldData>(),allServices.Single<SceneLoader>()),
                [typeof(GameLoopState)]=new GameLoopState(this)
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