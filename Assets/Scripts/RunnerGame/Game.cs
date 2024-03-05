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
            GameOver,
            Restart
        }

        public Game(LifetimeScope scope, ScoreManager scoreManager)
        {
            _sceneLoader = new SceneLoader(scope);
            StateMachine = new();
            StateMachine.InitStates(new Dictionary<GameStates,IGameState>()
            {
                [GameStates.MainMenu] = new MainMenuState(_sceneLoader),
                [GameStates.LoadLevel] = new LoadLevelState(_sceneLoader),
                [GameStates.GameOver] = new GameOverState(_sceneLoader),
                [GameStates.Restart] = new RestartState(this, scoreManager)
            });
            StateMachine.SetState(GameStates.MainMenu);
        }
    }
}