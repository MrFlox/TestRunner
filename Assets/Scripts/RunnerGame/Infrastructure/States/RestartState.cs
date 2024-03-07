using Shared;

namespace RunnerGame.Infrastructure.GameStates
{
    public class RestartState : IGameState
    {
        private IScoreManager _scoreManager;
        private readonly IStateMachine<GameStates> _game;
        public RestartState(IStateMachine<GameStates> game, IScoreManager scoreManager)
        {
            _game = game;
            _scoreManager = scoreManager;
        }
        public void EnterState()
        {
            _scoreManager.Clear();
            _game.SetState(GameStates.LoadLevel);
        }
    }
}