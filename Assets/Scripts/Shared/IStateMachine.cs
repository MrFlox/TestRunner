using System.Collections.Generic;
using RunnerGame.Infrastructure.GameStates;

namespace Shared
{
    public interface IStateMachine<T>
    {
        void SetState(T state);
        void InitStates(Dictionary<T, IGameState> states);
    }
}