using System.Collections.Generic;
using RunnerGame.Infrastructure.States;

namespace RunnerGame.Services
{
    public interface IStateMachine<T>
    {
        void SetState(T state);
        void InitStates(Dictionary<T, IGameState> states);
    }
}