using Shared;
using UnityEngine;
using VContainer;

namespace RunnerGame.Infrastructure.GameStates
{
    public class LoadLevelState : LoadSceneState
    {
        private static string[] _levels = { Levels.Level1, Levels.Level2 };
        public LoadLevelState(string defaultSceneName = null)
            : base(defaultSceneName ?? GetRandomLevel())
        {
        }
        private static string GetRandomLevel() => _levels[Random.Range(0, _levels.Length)];
        public override void EnterState()
        {
            _sceneName = GetRandomLevel();
            base.EnterState();
        }
    }
}