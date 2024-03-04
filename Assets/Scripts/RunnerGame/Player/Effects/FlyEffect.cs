using UnityEngine;

namespace RunnerGame.Player.Effects
{
    [CreateAssetMenu(menuName = "Coins/FlyEffect", fileName = "FlyEffect", order = 0)]
    class FlyEffect : CoinEffectSo
    {
        protected override void EnableTheEffect() => _player.Fly();
        protected override void DisableTheEffect() => _player.StopFly();
    }
}