namespace Infrastructure
{
    public class GameLoopState:IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            //Start game
            
        }

        public void Exit()
        {
            
        }
    }
}