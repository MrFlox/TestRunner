using RunnerGame.Player.Effects;

namespace RunnerGame.LevelItems
{
    public interface ICoinView
    {
        void SetCoinStyle(CoinEffectSo effect);
        void SetDefaultCoinStyle();
    }
}