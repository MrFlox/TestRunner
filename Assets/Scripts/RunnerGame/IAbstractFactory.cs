namespace RunnerGame
{
    public interface IAbstractFactory<T>
    {
        T Create();
        void Release(T segment);
    }
}