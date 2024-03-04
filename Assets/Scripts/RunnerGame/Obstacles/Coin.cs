using RunnerGame.Player.Effects;
using UnityEngine;

namespace RunnerGame.Obstacles
{
    public class Coin : MonoBehaviour
    {
        private const string Player = "Player";
        [SerializeField] CoinEffectSo effect;

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            Destroy(gameObject);
            other.transform.parent.GetComponent<Player.Player>().ApplyEffect(effect);
        }
    }
}