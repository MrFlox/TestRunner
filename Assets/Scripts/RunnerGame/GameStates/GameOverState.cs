using Shared;

namespace RunnerGame.GameStates
{
    public class GameOverState:IGameState
    {
        private const string SceneName = "GameOver";
        private readonly SceneLoader _sceneLoader;
        public GameOverState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void EnterState()
        {
            _sceneLoader.LoadScene(SceneName);
        }
    }
}