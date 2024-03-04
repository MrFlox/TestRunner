using RunnerGame.Player.Effects;
using UnityEngine;

namespace RunnerGame.Obstacles
{
    public class Coin : MonoBehaviour
    {
        private const string Player = "Player";
        [SerializeField] private CoinEffectSo effect;
        [SerializeField] private MeshRenderer mesh;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            Destroy(gameObject);
            other.transform.parent.TryGetComponent<Player.Player>(out var player);
            if (player != null)
            {
                if(effect!=null)
                    player.ApplyEffect(effect);
                player.CollectCoin();
            }
        }
    }
}