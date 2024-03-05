using Shared;

namespace RunnerGame.GameStates
{
    public class GameOverState:IGameState
    {
        private readonly SceneLoader _sceneLoader;
        public GameOverState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void EnterState()
        {
            throw new System.NotImplementedException();
        }
    }
}