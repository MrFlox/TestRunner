using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Shared
{
    public class SceneLoader : ISceneLoader
    {
        public SceneLoader(LifetimeScope currentScope) => _currentScope = currentScope;
        private readonly LifetimeScope _currentScope;
        async UniTask LoadSceneAsync(string sceneName)
        {
            using (LifetimeScope.EnqueueParent(_currentScope))
            {
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            }
        }
        public void LoadScene(string sceneName, Action onComplete=null) => LoadSceneAsync(sceneName);
    }
}