namespace RunnerGame.Infrastructure
{
    public interface IChangeState
    {
        void SetState(GameStates.GameStates newState);
    }
}