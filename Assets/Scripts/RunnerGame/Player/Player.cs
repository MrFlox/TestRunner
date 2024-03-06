using System;
using RunnerGame.Player.Effects;
using Shared;
using UnityEngine;
using VContainer;

namespace RunnerGame.Player
{


    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        private ScoreManager _scoreManager;
        private Game _game;
        private IInputController _inputController;
        private PlayerMovement _movement;
        [Inject] private void Construct(ScoreManager scoreManager, Game game)
        {
            _scoreManager = scoreManager;
            _game = game;
        }
        private void Awake() => _movement = GetComponent<PlayerMovement>();
        public void CollectCoin() => _scoreManager.Add();
        public void ApplyEffect(CoinEffectSo effect) => effect?.ApplyEffect(_movement);
        public void Hit()
        {
            _movement.Release();
            _game.SetState(Game.GameStates.GameOver);
        }
    }
}