﻿using System;
using System.Collections;
using UnityEngine;

namespace RunnerGame.Player.Effects
{
    /**
     * Base Coin Effect. Other must derive from it.
     */
    public class CoinEffectSo : ScriptableObject, IEffect
    {
        [SerializeField] private Material material;
        [SerializeField] private float delay = 10;
        protected PlayerMovement _playerMovement;
        public void ApplyEffect(PlayerMovement player)
        {
            _playerMovement = player.GetComponent<PlayerMovement>();
            _playerMovement.StartCoroutine(EnableEffect());
        }
        public Material Material => material;
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