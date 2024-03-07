using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace RunnerGame.Services
{
    public class SceneLoader : ISceneLoader
    {
        public SceneLoader(LifetimeScope currentScope) => _currentScope = currentScope;
        private readonly LifetimeScope _currentScope;
        private async UniTask LoadSceneAsync(string sceneName)
        {
            using (LifetimeScope.EnqueueParent(_currentScope))
            {
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            }
        }
        public void LoadScene(string sceneName, Action onComplete=null) => LoadSceneAsync(sceneName);
    }
}