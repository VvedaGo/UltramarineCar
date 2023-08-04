using Game;
using Infrastructure.Services;

namespace Infrastructure
{
    public class GameLoadInfoState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly GameFactory _gameFactory;
        private readonly UiGameFactory _uiGameFactory;
        private readonly WorldData _worldData;
        private readonly SceneLoader _sceneLoader;

        public GameLoadInfoState(GameStateMachine gameStateMachine, GameFactory gameFactory,
            UiGameFactory uiGameFactory, WorldData worldData, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _uiGameFactory = uiGameFactory;
            _worldData = worldData;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Car car = _gameFactory.SpawnCar();

            GameHud gameHud = _uiGameFactory.CreateGameHud();
            gameHud.Initialize(_gameStateMachine, _sceneLoader, _worldData, car);
            //toDo:Spawn gameHud
            //iitialize game hud
            //spawn car
            //initialize car
            // create way Builder
            _gameStateMachine.Enter<GameLoopState>();
            
        }

        public void Exit()
        {
        }
    }
}