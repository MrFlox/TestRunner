using System;
using System.Collections;
using UnityEngine;

namespace RunnerGame.Player
{
    class RunnerEffect
    {
        readonly float _delay = 10;
        protected RunnerGame.Player.Player _player;
        public RunnerEffect(RunnerGame.Player.Player player)
        {
            _player = player;
        }
        public void ApplyEffect()
        {
            _player.StartCoroutine(EnableEffect());
        }
        private IEnumerator EnableEffect()
        {
            EnableTheEffect();
            yield return new WaitForSeconds(_delay);
            DisableTheEffect();
        }
        protected virtual void EnableTheEffect()
        {
            throw new NotImplementedException();
        }

        protected virtual void DisableTheEffect()
        {
            throw new NotImplementedException();
        }
    }
}