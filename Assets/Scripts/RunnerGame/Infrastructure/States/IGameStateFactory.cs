namespace RunnerGame.Infrastructure.GameStates
{
    public interface IGameStateFactory
    {
        IGameState NewLoadScene(string SceneName);
        IGameState NewLoadLevel();
        IGameState CreateRestart();
    }
}