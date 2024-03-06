using VContainer;

namespace RunnerGame.GameStates
{
    public class RestartState : IGameState
    {
        private ScoreManager _scoreManager;
        private readonly Game _game;
        public RestartState(Game game, ScoreManager scoreManager)
        {
            _game = game;
            _scoreManager = scoreManager;
        }
        public void EnterState()
        {
            _scoreManager.Clear();
            _game.SetState(Game.GameStates.LoadLevel);
        }
    }
}