using RunnerGame.Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class ButtonGoToState : MonoBehaviour
    {
        [SerializeField] private Button buttonPlay;
        [SerializeField] private GameStates nextState;
        private IGame _game;
        [Inject]
        public void Construct(IGame game) => _game = game;
        private void Awake() => buttonPlay.onClick.AddListener(OnClickHandler);
        private void OnClickHandler() => _game.SetState(nextState);
    }
}