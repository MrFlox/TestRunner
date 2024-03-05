using System;

namespace Shared
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onComplete=null);
    }
}