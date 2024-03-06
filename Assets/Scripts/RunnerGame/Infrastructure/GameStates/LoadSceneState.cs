using Shared;
using VContainer;

namespace RunnerGame.Infrastructure.GameStates
{
    public class LoadSceneState : IGameState
    {
        [Inject] private SceneLoader _sceneLoader;
        protected string _sceneName;

        public LoadSceneState(string sceneName)
        {
            _sceneName = sceneName;
        }
        public virtual void EnterState() => _sceneLoader.LoadScene(_sceneName);
    }
}