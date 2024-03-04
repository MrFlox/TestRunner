using System;
using UnityEngine;

namespace RunnerGame
{
    public class ScoreManager : MonoBehaviour
    {
        private int score;

        public event Action<int> OnChangeScore;

        public void Add(int value = 1)
        {
            score += value;
            OnChangeScore?.Invoke(score);
        }

    }
}