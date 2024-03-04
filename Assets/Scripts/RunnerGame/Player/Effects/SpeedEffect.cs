﻿using UnityEngine;

namespace RunnerGame.Player.Effects
{
    [CreateAssetMenu(menuName = "Coins/SpeedEffect", fileName = "SpeedEffect", order = 0)]
    class SpeedEffect : CoinEffectSo
    {
        protected override void EnableTheEffect() => _player.movingVelocity *= 1.5f;
        protected override void DisableTheEffect() => _player.movingVelocity /= 1.5f;
    }
}