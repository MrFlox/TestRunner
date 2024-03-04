using RunnerGame.Player;

namespace RunnerGame.Effects
{
    class FlyEffect : RunnerEffect
    {
        public FlyEffect(Player.Player player) : base(player)
        {
        }
        protected override void EnableTheEffect() => _player.Fly();

        protected override void DisableTheEffect() => _player.StopFly();
    }
}