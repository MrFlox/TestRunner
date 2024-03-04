namespace RunnerGame
{
    class Effect1 : RunnerEffect
    {
        public Effect1(Player player) : base(player)
        {
        }

        protected override void EnableTheEffect()
        {
            _player.movingVelocity *= .5f;
        }

        protected override void DisableTheEffect()
        {
            _player.movingVelocity /= .5f;
        }
    }
}