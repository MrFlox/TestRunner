using System.Collections.Generic;

namespace RunnerGame.Services
{
    public interface IAbstractFactory<T>
    {
        T Create();
        void Release(T segment);
        void Init(List<T> variants, int defaultCapacity = 15);
    }
}