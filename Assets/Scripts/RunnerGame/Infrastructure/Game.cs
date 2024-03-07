using System.Collections.Generic;
using RunnerGame.Infrastructure.GameStates;
using Shared;
using UnityEngine;
using VContainer.Unity;

namespace RunnerGame.Infrastructure
{
    public class Game : IStartable, IGame
    {
        private StateMachine<GameStates> _stateMachine;
        public enum GameStates
        {
            None,
            MainMenu,
            LoadLevel,
            GameOver,
            Restart
        }

        public Game(ScoreManager scoreManager, ISceneLoader sceneLoader)
        {
            Application.targetFrameRate = 60;
            _stateMachine = new();
            _stateMachine.InitStates(new Dictionary<GameStates,IGameState>()
            {
                [GameStates.MainMenu] = new LoadSceneState(sceneLoader, Scenes.MAIN_MENU),
                [GameStates.LoadLevel] = new LoadLevelState(sceneLoader),
                // [GameStates.LoadLevel] = new LoadLevelState(sceneLoader, Scenes.DEFAULT_LEVEL),
                [GameStates.GameOver] = new LoadSceneState(sceneLoader, Scenes.GAME_OVER_SCENE),
                [GameStates.Restart] = new RestartState(this, scoreManager)
            });
        }
        public void SetState(GameStates newState) => _stateMachine.SetState(newState);
        void IStartable.Start() => SetState(GameStates.MainMenu);
    }
}