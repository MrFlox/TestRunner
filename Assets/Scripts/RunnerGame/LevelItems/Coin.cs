using RunnerGame.Player.Effects;
using RunnerGame.Segments;
using UnityEngine;

namespace RunnerGame.Obstacles
{
    public class Coin : MonoBehaviour
    {
        private const string Player = "Player";
        [SerializeField] private CoinEffectSo effect;
        [SerializeField] private MeshRenderer mesh;
        private Segment _segment;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            _segment.RemoveCoin(this);
            other.transform.parent.TryGetComponent<Player.Player>(out var player);
            if (player != null)
            {
                if(effect!=null)
                    player.ApplyEffect(effect);
                player.CollectCoin();
            }
        }
        public void SetSegment(Segment segment) => _segment = segment;
    }
}