using RunnerGame.Infrastructure.GameStates;
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
            builder.Register<StateMachine<GameStates.GameStates>>(Lifetime.Singleton).As<IStateMachine<GameStates.GameStates>>();
            builder.RegisterComponent(swiper).As<ISwiper>();
            builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ScoreManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameStateFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterEntryPoint<InputController>().As<IInputController>().As<ITickable>();
            builder.RegisterEntryPoint<Game>().As<IGame>();
            DontDestroyOnLoad(gameObject);
        }
    }
}