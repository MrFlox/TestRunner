using Shared;
using UnityEngine;

namespace RunnerGame.Infrastructure.GameStates
{
    public class LoadLevelState : LoadSceneState
    {
        private static string[] _levels = {Levels.Level1, Levels.Level2};
        public LoadLevelState(SceneLoader sceneLoader, string defaultSceneName=null)
            : base(sceneLoader, defaultSceneName??GetRandomLevel())
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