using Shared;
using VContainer;

namespace RunnerGame.Infrastructure.GameStates
{
    public class LoadSceneState : IGameState
    {
        private ISceneLoader _sceneLoader;
        protected string _sceneName;

        public LoadSceneState(ISceneLoader sceneLoader, string sceneName)
        {
            _sceneLoader = sceneLoader;
            _sceneName = sceneName;
        }
        public virtual void EnterState() => _sceneLoader.LoadScene(_sceneName);
    }
}