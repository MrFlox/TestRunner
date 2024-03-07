using RunnerGame.Infrastructure;
using RunnerGame.Player.Effects;
using RunnerGame.Services;
using UnityEngine;
using VContainer;

namespace RunnerGame.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        private IScoreManager _scoreManager;
        private IGame _game;
        private IInputController _inputController;
        private PlayerMovement _movement;
        [Inject] private void Construct(IScoreManager scoreManager, IGame game)
        {
            _scoreManager = scoreManager;
            _game = game;
        }
        private void Awake() => _movement = GetComponent<PlayerMovement>();
        public void CollectCoin() => _scoreManager.Add();
        public void ApplyEffect(IEffect effect) => effect?.ApplyEffect(_movement);
        public void Hit()
        {
            _movement.Release();
            _game.SetState(GameStates.GameOver);
        }
    }
}