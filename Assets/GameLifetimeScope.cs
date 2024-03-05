using RunnerGame;
using TriInspector;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    private Game _game;
    protected override void Configure(IContainerBuilder builder)
    {
        var scoreManager = new ScoreManager();
        builder.RegisterInstance(scoreManager);
        _game = new Game(this, scoreManager);
        builder.RegisterInstance(_game);
        DontDestroyOnLoad(gameObject);
    }
    [Button]
    public void ChangeState(Game.GameStates state) => _game.StateMachine.SetState(state);
}