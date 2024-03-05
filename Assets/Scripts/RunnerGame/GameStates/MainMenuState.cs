using Shared;

namespace RunnerGame.GameStates
{
    public class MainMenuState : IGameState
    {
        private const string SceneName = "MainMenu";
        private readonly SceneLoader _sceneLoader;
        public MainMenuState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        public void EnterState()
        {
            _sceneLoader.LoadScene(SceneName);
        }
    }
}