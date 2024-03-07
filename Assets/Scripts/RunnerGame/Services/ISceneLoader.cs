using System;

namespace RunnerGame.Services
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onComplete=null);
    }
}