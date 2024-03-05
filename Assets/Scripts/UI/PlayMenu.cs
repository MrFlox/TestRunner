using RunnerGame;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class PlayMenu : MonoBehaviour
    {
        [SerializeField] private Button buttonPlay;
        private Game _game;

        [Inject]
        public void Construct(Game game)
        {
            _game = game;
        }
        private void Awake() => buttonPlay.onClick.AddListener(OnClickHandler);
        private void OnClickHandler() => _game.StateMachine.SetState(Game.GameStates.LoadLevel);
    }
}