using Game;

namespace Infrastructure
{
    public class LoadInfoState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UiGameFactory _uiGameFactory;
        private readonly WorldData _worldData;

        public LoadInfoState(GameStateMachine gameStateMachine,SceneLoader sceneLoader,UiGameFactory uiGameFactory,WorldData worldData)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiGameFactory = uiGameFactory;
            _worldData = worldData;
        }

        public void Enter()
        {
          MenuHud hud=  _uiGameFactory.CreateMenuHud();
          hud.Initialize(_sceneLoader,_gameStateMachine,_worldData);
        }

        public void Exit()
        {
        
        }

    }
}