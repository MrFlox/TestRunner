using System.Collections.Generic;
using RunnerGame.GameStates;
using Shared;
using VContainer.Unity;

namespace RunnerGame
{
    public class Game
    {
        public readonly StateMachine<GameStates> StateMachine;
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
            var sceneLoader = new SceneLoader(scope);
            StateMachine = new();
            StateMachine.InitStates(new Dictionary<GameStates,IGameState>()
            {
                [GameStates.MainMenu] = new LoadSceneState(sceneLoader, Scenes.MAIN_MENU),
                [GameStates.LoadLevel] = new LoadSceneState(sceneLoader, Scenes.LEVEL_SCENE),
                [GameStates.GameOver] = new LoadSceneState(sceneLoader, Scenes.GAME_OVER_SCENE),
                [GameStates.Restart] = new RestartState(this, scoreManager)
            });
            StateMachine.SetState(GameStates.MainMenu);
        }
    }
}