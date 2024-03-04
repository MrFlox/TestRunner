namespace RunnerGame
{
    class Effect2 : RunnerEffect
    {
        public Effect2(Player player) : base(player)
        {
        }
        protected override void EnableTheEffect()
        {
            _player.movingVelocity *= 1.5f;
        }

        protected override void DisableTheEffect()
        {
            _player.movingVelocity /= 1.5f;
        }
    }
}