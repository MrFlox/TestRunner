using RunnerGame.Player.Effects;
using UnityEngine;

namespace RunnerGame.LevelItems
{
    public class CoinView : MonoBehaviour, ICoinView
    {
        [SerializeField] private Material defaulCoinMaterial;
        [SerializeField] private MeshRenderer mesh;
        public void SetCoinStyle(CoinEffectSo effect) => mesh.material = effect.Material;
        public void SetDefaultCoinStyle() => mesh.material = defaulCoinMaterial;
    }
}