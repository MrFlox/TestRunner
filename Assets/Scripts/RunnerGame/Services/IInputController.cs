using System;

namespace RunnerGame.Services
{
    public interface IInputController
    {
        void Start(Action<SwipeDirection> onMove);
        void Stop(Action<SwipeDirection> onMove);
    }
}