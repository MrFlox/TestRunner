using System;
using System.Collections.Generic;
using RunnerGame.Infrastructure.GameStates;
using TriInspector;

namespace Shared
{
    public class StateMachine<TStatesEnum> : IStateMachine<TStatesEnum> where TStatesEnum: Enum
    {
        public event Action<TStatesEnum> OnChangeState;
        Dictionary<TStatesEnum, IGameState> _states;
        TStatesEnum _currentState;
        public void InitStates(Dictionary<TStatesEnum, IGameState> states) => _states = states;
        [Button]
        public void SetState(TStatesEnum newState)
        {
            if (_currentState.Equals(newState)) return;
            _currentState = newState;
            OnChangeState?.Invoke(_currentState);
            _states[newState].EnterState();
        }
    }
}