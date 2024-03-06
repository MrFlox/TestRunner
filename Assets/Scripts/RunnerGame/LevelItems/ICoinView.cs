using RunnerGame.Player.Effects;

namespace RunnerGame.LevelItems
{
    public interface ICoinView
    {
        void SetCoinStyle(IEffect effect);
        void SetDefaultCoinStyle();
    }
}