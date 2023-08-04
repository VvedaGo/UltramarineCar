
using Infrastructure.Services;

namespace Infrastructure
{
    public class GameLoadInfoState:IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly GameFactory _gameFactory;
        private readonly UiGameFactory _uiGameFactory;

        public GameLoadInfoState(GameStateMachine gameStateMachine,GameFactory gameFactory,UiGameFactory uiGameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _uiGameFactory = uiGameFactory;
        }

        public void Enter()
        {
            //toDo:Spawn gameHud
            //iitialize game hud
            //spawn car
            //initialize car
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
        }

        
    }
}