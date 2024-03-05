using RunnerGame;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    public class HelloWorldService
    {
        public void Hello()
        {
            Debug.Log("Hello world!");
        }
    }

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(new Game());
        builder.Register<HelloWorldService>(Lifetime.Singleton);
    }
}