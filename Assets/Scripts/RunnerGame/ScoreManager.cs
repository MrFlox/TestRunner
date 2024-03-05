using System;
using UnityEngine;

namespace RunnerGame
{
    public class ScoreManager
    {
        private int _score;
        public event Action<int> OnChangeScore;
        public int Value => _score;
        public void Add(int value = 1)
        {
            _score += value;
            OnChangeScore?.Invoke(_score);
        }
        public void Clear() => _score = 0;
    }
}