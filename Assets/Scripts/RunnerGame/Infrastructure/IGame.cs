namespace RunnerGame.Infrastructure
{
    public interface IGame
    {
        void SetState(Game.GameStates newState);
    }
}