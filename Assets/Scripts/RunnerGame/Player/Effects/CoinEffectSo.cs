using System;
using System.Collections;
using UnityEngine;

namespace RunnerGame.Player.Effects
{
    public class CoinEffectSo : ScriptableObject
    {
        public Material Material;
        [SerializeField] private float delay = 10;
        protected Player _player;
        public void ApplyEffect(Player player)
        {
            _player = player;
            _player.StartCoroutine(EnableEffect());
        }
        private IEnumerator EnableEffect()
        {
            EnableTheEffect();
            yield return new WaitForSeconds(delay);
            DisableTheEffect();
        }
        protected virtual void EnableTheEffect() => throw new NotImplementedException();
        protected virtual void DisableTheEffect() => throw new NotImplementedException();
    }
}