using System.Collections.Generic;
using RunnerGame.GameStates;
using Shared;

namespace RunnerGame
{
    public class Game
    {
        private StateMachine<GameStates> _stateMachine;
        private SceneLoader _sceneLoader;
        public enum GameStates
        {
            None,
            MainMenu,
            LoadLevel,
            GameOver
        }

        public Game()
        {
            _sceneLoader = new SceneLoader();
            _stateMachine = new();
            _stateMachine.InitStates(new Dictionary<GameStates,IGameState>()
            {
                [GameStates.MainMenu] = new MainMenuState(_sceneLoader),
                [GameStates.LoadLevel] = new LoadLevelState(_sceneLoader),
                [GameStates.GameOver] = new GameOverState(_sceneLoader)
            });

            _stateMachine.SetState(GameStates.MainMenu);
        }
    }
}