using RunnerGame.Infrastructure.States;

namespace RunnerGame.Infrastructure.Services
{
    public interface IGameStateFactory
    {
        IGameState NewLoadScene(string SceneName);
        IGameState NewLoadLevel();
        IGameState CreateRestart();
    }
}