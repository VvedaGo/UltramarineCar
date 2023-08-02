using System.ComponentModel;

public class BootstrapState:IGameState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly AllServices _allServices;

    public BootstrapState(GameStateMachine gameStateMachine, AllServices allServices)
    {
        _gameStateMachine = gameStateMachine;
        _allServices = allServices;
    }
    public void Enter()
    {
        _allServices.RegisterSingle<AssetProvider>(new AssetProvider());
        _allServices.RegisterSingle<UiGameFactory>(new UiGameFactory(_allServices.Single<AssetProvider>()));
        
    }

    public void Exit()
    {
        
    }
}