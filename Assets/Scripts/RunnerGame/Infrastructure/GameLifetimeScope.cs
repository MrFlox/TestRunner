using RunnerGame.Infrastructure.Services;
using RunnerGame.LevelItems.Coins;
using RunnerGame.LevelItems.Segments;
using RunnerGame.Services;
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
            RegisterFactories(builder);
            RegisterServices(builder);
            RegisterMonoBehaviors(builder);
            RegisterEntryPoints(builder);
            DontDestroyOnLoad(gameObject);
        }
        private static void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<StateMachine<GameStates>>(Lifetime.Singleton).As<IStateMachine<GameStates>>();
            builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ScoreManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameStateFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
        private void RegisterMonoBehaviors(IContainerBuilder builder) =>
            builder.RegisterComponent(swiper).As<ISwiper>();
        private static void RegisterEntryPoints(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<InputController>().As<IInputController>().As<ITickable>();
            builder.RegisterEntryPoint<Game>().As<IGame>();
        }
        private static void RegisterFactories(IContainerBuilder builder)
        {
            RegisterAbstractFactoryOfType<Segment>(builder);
            RegisterAbstractFactoryOfType<Coin>(builder);
        }
        private static void RegisterAbstractFactoryOfType<T>(IContainerBuilder builder) where T: MonoBehaviour =>
            builder.Register<ItemFactory<T>>(Lifetime.Singleton).As<IAbstractFactory<T>>();
    }
}