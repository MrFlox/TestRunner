namespace Shared
{
    public interface IStateManager<T>
    {
        void SetState(T state);
    }
}