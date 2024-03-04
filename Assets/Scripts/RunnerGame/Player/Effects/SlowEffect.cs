using RunnerGame.Player;

namespace RunnerGame.Effects
{
    class SlowEffect : RunnerEffect
    {
        public SlowEffect(Player.Player player) : base(player)
        {
        }

        protected override void EnableTheEffect() => _player.movingVelocity *= .5f;
        protected override void DisableTheEffect() => _player.movingVelocity /= .5f;
    }
}