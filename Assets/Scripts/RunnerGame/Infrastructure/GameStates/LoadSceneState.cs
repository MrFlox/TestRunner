using Shared;

namespace RunnerGame.Infrastructure.GameStates
{
    public class LoadSceneState : IGameState
    {
        private readonly SceneLoader _sceneLoader;
        protected string _sceneName;
        public LoadSceneState(SceneLoader sceneLoader, string sceneName)
        {
            _sceneLoader = sceneLoader;
            _sceneName = sceneName;
        }
        public virtual void EnterState() => _sceneLoader.LoadScene(_sceneName);
    }
}