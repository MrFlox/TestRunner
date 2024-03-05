using UnityEngine;

namespace RunnerGame
{
    public class BootStrap : MonoBehaviour
    {
        private Game _game;
        private void Awake()
        {
            _game = new Game();
            DontDestroyOnLoad(gameObject);
        }
    }
}