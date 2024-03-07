namespace RunnerGame.Infrastructure.GameStates
{
    public class RestartState : IGameState
    {
        private ScoreManager _scoreManager;
        private readonly IGame _game;
        public RestartState(IGame game, ScoreManager scoreManager)
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