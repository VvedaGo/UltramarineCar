namespace Infrastructure.GameStateMachine
{
    public interface IGameState
    {
        void Enter();
        void Exit();
    }
}