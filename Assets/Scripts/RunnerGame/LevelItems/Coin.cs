using System;
using System.Collections.Generic;
using RunnerGame.Player.Effects;
using RunnerGame.Segments;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RunnerGame.Obstacles
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private List<CoinEffectSo> coinTypes;
        [SerializeField] private Material defaulCoinMaterial;
        private const string Player = "Player";
        [SerializeField] private CoinEffectSo effect;
        [SerializeField] private MeshRenderer mesh;
        private Segment _segment;
        private Color _defaultColor;
        private void Awake()
        {
            _defaultColor = mesh.material.color;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            _segment.RemoveCoin(this);
            other.transform.parent.TryGetComponent<Player.Player>(out var player);
            if (player != null)
            {
                if(effect!=null)
                    player.ApplyEffect(effect);
                player.CollectCoin();
            }
        }
        public void SetSegment(Segment segment) => _segment = segment;
        public void SetRandomType()
        {
            var randomType =coinTypes[Random.Range(0, coinTypes.Count)];
            if (Random.value < .1f)
            {
                effect = randomType;
                mesh.material = effect.Material;
                return;
            }
            effect = null;
            mesh.material = defaulCoinMaterial;
        }
    }
}