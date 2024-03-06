using RunnerGame;
using RunnerGame.Player;
using Shared;
using TriInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Swiper swiper;
    private Game _game;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(swiper).As<ISwiper>();
        var scoreManager = new ScoreManager();
        builder.RegisterInstance(scoreManager);
        _game = new Game(this, scoreManager);
        builder.RegisterInstance(_game);
        DontDestroyOnLoad(gameObject);
        builder.RegisterEntryPoint<InputController>().As<IInputController>();
    }
    [Button]
    public void ChangeState(Game.GameStates state) => _game.SetState(state);
}