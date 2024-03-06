using RunnerGame.Player.Effects;
using UnityEngine;
using UnityEngine.Serialization;

namespace RunnerGame.LevelItems
{
    public class CoinView : MonoBehaviour, ICoinView
    {
        [FormerlySerializedAs("defaulCoinMaterial")] [SerializeField] private Material defaultCoinMaterial;
        [SerializeField] private MeshRenderer mesh;
        public void SetCoinStyle(IEffect effect) => mesh.material = effect.Material;
        public void SetDefaultCoinStyle() => mesh.material = defaultCoinMaterial;
    }
}