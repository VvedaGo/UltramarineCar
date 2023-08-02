namespace Infrastructure
{
    public class LoadInfoState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UiGameFactory _uiGameFactory;

        public LoadInfoState(GameStateMachine gameStateMachine,SceneLoader sceneLoader,UiGameFactory uiGameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiGameFactory = uiGameFactory;
        }

        public void Enter()
        {
            _uiGameFactory.CreateMenuHud();
        }

        public void Exit()
        {
        
        }

    }
}