using Shared;

namespace RunnerGame.GameStates
{
    public class LoadLevelState : IGameState
    {
        private const string SceneName = "Level";
        private readonly SceneLoader _sceneLoader;
        public LoadLevelState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        public void EnterState()
        {
            _sceneLoader.LoadScene(SceneName);
        }
    }
}