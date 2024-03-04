using System;

namespace Shared
{
    public interface ISwiper
    {
        event Action<SwipeDirection> OnSwipe;
    }
}