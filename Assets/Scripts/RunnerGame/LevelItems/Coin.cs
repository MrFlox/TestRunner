using System;
using System.Collections.Generic;
using RunnerGame.Player.Effects;
using RunnerGame.Segments;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RunnerGame.LevelItems
{
    [RequireComponent(typeof(ICoinView))]
    public class Coin : MonoBehaviour
    {
        private const string Player = "Player";
        [SerializeField] private List<CoinEffectSo> coinTypes;
        private CoinEffectSo effect;
        private Segment _segment;
        private ICoinView _view;
        private void Awake() => _view = GetComponent<ICoinView>();
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            _segment.RemoveCoin(this);
            other.transform.parent.TryGetComponent<Player.Player>(out var player);
            if (player == null) return;
            if (effect != null)
                player.ApplyEffect(effect);
            player.CollectCoin();
        }
        public void SetSegment(Segment segment) => _segment = segment;
        public void SetRandomType()
        {
            var randomType =coinTypes[Random.Range(0, coinTypes.Count)];
            if (Random.value < .1f)
            {
                effect = randomType;
                _view.SetCoinStyle(effect);
                return;
            }
            effect = null;
            _view.SetDefaultCoinStyle();
        }
    }
}