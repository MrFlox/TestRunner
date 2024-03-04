using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shared
{
    public enum SwipeDirection
    {
        Left, Right, Top, Bottom
    }
    public class Swiper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, ISwiper
    {
        public float SwipeThreshold = 50f;
        private Vector2 _swipeStartPosition;
        private Vector2 _swipeEndPosition;

        public event Action<SwipeDirection> OnSwipe;

        public void OnPointerDown(PointerEventData eventData) =>
            _swipeStartPosition = eventData.position;
        public void OnPointerUp(PointerEventData eventData)
        {
            _swipeEndPosition = eventData.position;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            var swipeDistance = Vector2.Distance(_swipeStartPosition, _swipeEndPosition);

            if (swipeDistance > SwipeThreshold)
            {
                var direction = _swipeEndPosition - _swipeStartPosition;
                direction.Normalize();

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x > 0)
                        OnSwipe?.Invoke(SwipeDirection.Right);
                    else
                        OnSwipe?.Invoke(SwipeDirection.Left);
                }
                else
                {
                    if (direction.y > 0)
                        OnSwipe?.Invoke(SwipeDirection.Top);
                    else
                        OnSwipe?.Invoke(SwipeDirection.Bottom);
                }
            }
        }
    }
}