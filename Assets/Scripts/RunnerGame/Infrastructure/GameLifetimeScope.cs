using RunnerGame.Player;
using Shared;
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
            builder.RegisterComponent(swiper).As<ISwiper>();
            builder.Register<SceneLoader>(Lifetime.Singleton).As<ISceneLoader>();
            builder.Register<ScoreManager>(Lifetime.Singleton);
            builder.RegisterEntryPoint<InputController>().As<IInputController>();
            builder.RegisterEntryPoint<Game>().As<IGame>();
            DontDestroyOnLoad(gameObject);
        }
    }
}