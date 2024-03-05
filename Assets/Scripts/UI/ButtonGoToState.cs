using RunnerGame;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class ButtonGoToState : MonoBehaviour
    {
        [SerializeField] private Button buttonPlay;
        [SerializeField] private Game.GameStates nextState;
        private Game _game;
        [Inject]
        public void Construct(Game game) => _game = game;
        private void Awake() => buttonPlay.onClick.AddListener(OnClickHandler);
        private void OnClickHandler() => _game.StateMachine.SetState(nextState);
    }
}