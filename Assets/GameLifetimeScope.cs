using RunnerGame;
using TriInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    private Game _game;
    protected override void Configure(IContainerBuilder builder)
    {
        _game = new Game(this);
        builder.RegisterInstance(_game);
        DontDestroyOnLoad(gameObject);
    }

    [Button]
    public void ChangeState(Game.GameStates state)
    {
        _game.StateMachine.SetState(state);
    }
}