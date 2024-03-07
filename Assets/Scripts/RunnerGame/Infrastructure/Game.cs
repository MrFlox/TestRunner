using System.Collections.Generic;
using RunnerGame.Infrastructure.GameStates;
using Shared;
using UnityEngine;
using VContainer.Unity;

namespace RunnerGame.Infrastructure
{
    public class Game : IStartable, IGame
    {
        private IStateMachine<GameStates.GameStates> _stateMachine;
        private readonly GameStateFactory _stateFactory;

        public Game(IGameStateFactory stateFactory, IStateMachine<GameStates.GameStates> stateMachine)
        {
            Application.targetFrameRate = 60;
            _stateMachine = stateMachine;
            _stateMachine.InitStates(new Dictionary<GameStates.GameStates, IGameState>()
            {
                [GameStates.GameStates.MainMenu] = stateFactory.NewLoadScene(Scenes.MAIN_MENU),
                [GameStates.GameStates.LoadLevel] = stateFactory.NewLoadLevel(),
                [GameStates.GameStates.GameOver] = stateFactory.NewLoadScene(Scenes.GAME_OVER_SCENE),
                [GameStates.GameStates.Restart] = stateFactory.CreateRestart()
            });
        }
        public void SetState(GameStates.GameStates newState) => _stateMachine.SetState(newState);
        void IStartable.Start() => SetState(GameStates.GameStates.MainMenu);
    }
}