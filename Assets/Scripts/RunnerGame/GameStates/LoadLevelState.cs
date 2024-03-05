using Shared;

namespace RunnerGame.GameStates
{
    public class LoadLevelState:IGameState
    {
        private readonly SceneLoader _sceneLoader;
        public LoadLevelState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        public void EnterState()
        {
            _sceneLoader.LoadScene("Level");
        }
    }
}