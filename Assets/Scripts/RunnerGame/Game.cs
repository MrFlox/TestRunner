using System.Collections.Generic;
using RunnerGame.GameStates;
using Shared;
using VContainer.Unity;

namespace RunnerGame
{
    public class Game
    {
        public readonly StateMachine<GameStates> StateMachine;
        private SceneLoader _sceneLoader;
        public enum GameStates
        {
            None,
            MainMenu,
            LoadLevel,
            GameOver
        }

        public Game(LifetimeScope scope)
        {
            _sceneLoader = new SceneLoader(scope);
            StateMachine = new();
            StateMachine.InitStates(new Dictionary<GameStates,IGameState>()
            {
                [GameStates.MainMenu] = new MainMenuState(_sceneLoader),
                [GameStates.LoadLevel] = new LoadLevelState(_sceneLoader),
                [GameStates.GameOver] = new GameOverState(_sceneLoader)
            });
            StateMachine.SetState(GameStates.MainMenu);
        }
    }
}