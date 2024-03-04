namespace RunnerGame
{
    class Effect3 : RunnerEffect
    {
        public Effect3(Player player) : base(player)
        {
        }

        protected override void EnableTheEffect()
        {
            _player.Fly();
        }

        protected override void DisableTheEffect()
        {
            _player.StopFly();
        }
    }
}