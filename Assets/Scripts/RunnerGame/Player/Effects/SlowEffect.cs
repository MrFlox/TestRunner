using UnityEngine;

namespace RunnerGame.Player.Effects
{
    [CreateAssetMenu(menuName = "Coins/SlowEffect", fileName = "SlowEffect", order = 0)]
    class SlowEffect : CoinEffectSo
    {
        protected override void EnableTheEffect() => _player.movingVelocity *= .5f;
        protected override void DisableTheEffect() => _player.movingVelocity /= .5f;
    }
}