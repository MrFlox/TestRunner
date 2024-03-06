using RunnerGame.Player.Effects;

namespace RunnerGame.LevelItems.Coins
{
    public interface ICoinView
    {
        void SetCoinStyle(IEffect effect);
        void SetDefaultCoinStyle();
    }
}