
namespace Infrastructure
{
    public class GameLoadInfoState:IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameLoadInfoState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
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