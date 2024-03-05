using Shared;

namespace RunnerGame.GameStates
{
    public class LoadSceneState : IGameState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly string _sceneName;
        public LoadSceneState(SceneLoader sceneLoader, string sceneName)
        {
            _sceneLoader = sceneLoader;
            _sceneName = sceneName;
        }
        public void EnterState() => _sceneLoader.LoadScene(_sceneName);
    }
}