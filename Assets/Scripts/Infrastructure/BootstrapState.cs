using Infrastructure.Services;

namespace Infrastructure
{
    public class BootstrapState:IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _allServices;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices allServices,ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = allServices;
            _coroutineRunner = coroutineRunner;
            
            _allServices.RegisterSingle<AssetProvider>(new AssetProvider());
            _allServices.RegisterSingle<UiGameFactory>(new UiGameFactory(_allServices.Single<AssetProvider>()));
            _allServices.RegisterSingle<GameFactory>(new GameFactory(_allServices.Single<AssetProvider>()));
            _allServices.RegisterSingle<SceneLoader>(new SceneLoader(_coroutineRunner));
        }
        public void Enter()
        {
            _allServices.Single<SceneLoader>().Load("MenuScene", LoadSceneMenu);
        }

        public void Exit()
        {
        
        }

        private void LoadSceneMenu()
        {
            _gameStateMachine.Enter<LoadInfoState>();
        }
    }
}