using RunnerGame.Player;

namespace RunnerGame.Effects
{
    class SpeedEffect : RunnerEffect
    {
        public SpeedEffect(Player.Player player) : base(player)
        {
        }
        protected override void EnableTheEffect() => _player.movingVelocity *= 1.5f;
        protected override void DisableTheEffect() => _player.movingVelocity /= 1.5f;
    }
}