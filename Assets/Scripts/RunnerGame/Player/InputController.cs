using System;
using Shared;
using UnityEngine;
using VContainer.Unity;

namespace RunnerGame.Player
{
    public class InputController : IInputController, ITickable
    {
        private ISwiper _swiper;
        private event Action<SwipeDirection> OnMove;
        public InputController(ISwiper swiper) => _swiper = swiper;
        public void Start(Action<SwipeDirection> onMove)
        {
            OnMove += onMove;
            _swiper.Enable();
            _swiper.Subscribe(OnSwipeHandler);
        }
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.A))
                OnMove?.Invoke(SwipeDirection.Left);
            if (Input.GetKeyDown(KeyCode.D))
                OnMove?.Invoke(SwipeDirection.Right);
            if (Input.GetKeyDown(KeyCode.Space))
                OnMove?.Invoke(SwipeDirection.Top);
        }
        public void Stop(Action<SwipeDirection> onMove)
        {
            OnMove -= onMove;
            _swiper.Unsubscribe(OnSwipeHandler);
            _swiper.Disable();
        }
        private void OnSwipeHandler(SwipeDirection obj) => OnMove?.Invoke(obj);
    }
}