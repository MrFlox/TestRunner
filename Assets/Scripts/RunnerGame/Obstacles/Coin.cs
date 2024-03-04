using RunnerGame.Player.Effects;
using UnityEngine;

namespace RunnerGame.Obstacles
{
    public class Coin : MonoBehaviour
    {
        private const string Player = "Player";
        [SerializeField] private CoinEffectSo effect;
        [SerializeField] private MeshRenderer mesh;
        private void OnValidate()
        {
            if (effect != null)
                mesh.sharedMaterial.color = effect.color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            Destroy(gameObject);
            other.transform.parent.TryGetComponent<Player.Player>(out var player);
            if (player != null)
                player.ApplyEffect(effect);
        }
    }
}