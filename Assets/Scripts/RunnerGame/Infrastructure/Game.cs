using System.Collections.Generic;
using RunnerGame.Infrastructure.GameStates;
using Shared;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RunnerGame.Infrastructure
{
    public class Game
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

        private ScoreManager scoreManager;
        public Game(ScoreManager scoreManager)
        {
            this.scoreManager = scoreManager;

            Application.targetFrameRate = 60;
            _stateMachine = new();
            _stateMachine.InitStates(new Dictionary<GameStates,IGameState>()
            {
                [GameStates.MainMenu] = new LoadSceneState( Scenes.MAIN_MENU),
                [GameStates.LoadLevel] = new LoadLevelState(),
                // [GameStates.LoadLevel] = new LoadLevelState(sceneLoader, Scenes.DEFAULT_LEVEL),
                [GameStates.GameOver] = new LoadSceneState( Scenes.GAME_OVER_SCENE),
                [GameStates.Restart] = new RestartState(this, scoreManager)
            });
        }
        public void SetState(GameStates newState) => _stateMachine.SetState(newState);
    }
}