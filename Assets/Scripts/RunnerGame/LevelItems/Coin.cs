using System;
using System.Collections.Generic;
using RunnerGame.Player.Effects;
using RunnerGame.Segments;
using UnityEngine;

namespace RunnerGame.LevelItems
{
    [RequireComponent(typeof(ICoinView))]
    public class Coin : MonoBehaviour
    {
        private const string Player = "Player";
        private IEffect _effect;
        private Segment _segment;
        private ICoinView _view;
        private void Awake() => _view = GetComponent<ICoinView>();
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            _segment.RemoveCoin(this);
            other.transform.parent.TryGetComponent<Player.Player>(out var player);
            if (player == null) return;
            if (_effect != null)
                player.ApplyEffect(_effect);
            player.CollectCoin();
        }
        public void SetSegment(Segment segment) => _segment = segment;
        public void SetRandomType()
        {
            _effect = Randomizer.GetRandomEffect();
            if (_effect == null)
                _view.SetDefaultCoinStyle();
            else
                _view.SetCoinStyle(_effect);
        }
    }
}