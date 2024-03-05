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
            throw new System.NotImplementedException();
        }
    }
}