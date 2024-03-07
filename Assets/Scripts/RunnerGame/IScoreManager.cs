using System;

namespace RunnerGame
{
    public interface IScoreManager
    {
        event Action<int> OnChangeScore;
        int Value { get; }
        void Add(int value = 1);
        void Clear();
    }
}