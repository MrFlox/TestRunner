using RunnerGame;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(new Game(this));
        DontDestroyOnLoad(gameObject);
    }
}