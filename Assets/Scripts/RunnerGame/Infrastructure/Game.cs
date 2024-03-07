using System.Collections.Generic;
using RunnerGame.Infrastructure.Services;
using RunnerGame.Infrastructure.States;
using RunnerGame.Services;
using UnityEngine;
using VContainer.Unity;

namespace RunnerGame.Infrastructure
{
    public class Game : IStartable, IGame
    {
        private readonly IStateMachine<GameStates> _stateMachine;
        private readonly IGameStateFactory _stateFactory;
        void IStartable.Start() => SetState(GameStates.MainMenu);
        public Game(IGameStateFactory stateFactory, IStateMachine<GameStates> stateMachine)
        {
            Application.targetFrameRate = 60;
            _stateMachine = stateMachine;
            _stateMachine.InitStates(new Dictionary<GameStates, IGameState>
            {
                [GameStates.MainMenu] = stateFactory.NewLoadScene(Scenes.MAIN_MENU),
                [GameStates.LoadLevel] = stateFactory.NewLoadLevel(),
                [GameStates.GameOver] = stateFactory.NewLoadScene(Scenes.GAME_OVER_SCENE),
                [GameStates.Restart] = stateFactory.CreateRestart()
            });
        }
        public void SetState(GameStates newState) => _stateMachine.SetState(newState);
    }
}