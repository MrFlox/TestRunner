using System;

namespace RunnerGame.Services
{
    public interface ISwiper
    {

        void Subscribe(Action<SwipeDirection> onSwipe);
        void Unsubscribe(Action<SwipeDirection> onSwipe);
        void Disable();
        void Enable();
    }
}