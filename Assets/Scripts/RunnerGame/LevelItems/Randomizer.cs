using RunnerGame.Player.Effects;
using UnityEngine;

namespace RunnerGame.LevelItems
{
    public static class Randomizer
    {
        public const float Chance = .1f;
        private static CoinEffectSo[] coinTypes;
        static Randomizer()
        {
            coinTypes = Resources.LoadAll<CoinEffectSo>("Data/Effects");
        }
        public static IEffect GetRandomEffect()
        {
            var randomType = coinTypes[Random.Range(0, coinTypes.Length)];
            return Random.value < Chance ? randomType : null;
        }
    }
}