using System;
using UnityEngine.SceneManagement;

namespace Shared
{
    public class SceneLoader : ISceneLoader
    {
        static void LoadWithSceneManager(string sceneName, Action onComplete)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).completed += (_) => onComplete?.Invoke();
        }
        public void LoadScene(string sceneName, Action onComplete=null) =>
            LoadWithSceneManager(sceneName, onComplete);
    }
}