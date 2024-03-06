using System;
using Shared;
using VContainer.Unity;

namespace RunnerGame.Player
{
    public interface IInputController
    {
        void Start(Action<SwipeDirection> onMove);
        void Stop(Action<SwipeDirection> onMove);
    }
}