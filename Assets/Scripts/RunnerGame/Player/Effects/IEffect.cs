using UnityEngine;

namespace RunnerGame.Player.Effects
{
    public interface IEffect
    {
        void ApplyEffect(PlayerMovement player);
        Material Material { get; }
    }
}