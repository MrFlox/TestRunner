using RunnerGame.Player;
using Shared;
using TriInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RunnerGame.Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private Swiper swiper;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneLoader>(Lifetime.Singleton).As<ISceneLoader>();
            builder.RegisterComponent(swiper).As<ISwiper>();
            builder.Register<ScoreManager>(Lifetime.Singleton);
            builder.Register<Game>(Lifetime.Singleton);
            builder.RegisterEntryPoint<InputController>().As<IInputController>();

            DontDestroyOnLoad(gameObject);
        }
    }
}