using RunnerGame.Infrastructure.States;
using RunnerGame.Services;

namespace RunnerGame.Infrastructure.Services
{
    public class GameStateFactory : IGameStateFactory
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateMachine<GameStates> _stateMachine;
        private readonly IScoreManager _scoreManager;
        protected GameStateFactory(ISceneLoader sceneLoader, IStateMachine<GameStates> stateMachine, IScoreManager scoreManager)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _scoreManager = scoreManager;
        }
        public IGameState NewLoadScene(string sceneName) =>
            new LoadSceneState(_sceneLoader, sceneName);
        public IGameState NewLoadLevel() => new LoadLevelState(_sceneLoader);
        public IGameState CreateRestart() => new RestartState(_stateMachine, _scoreManager);
    }
}