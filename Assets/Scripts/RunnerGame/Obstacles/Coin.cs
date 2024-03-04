using UnityEngine;

namespace RunnerGame.Obstacles
{
    public class Coin : MonoBehaviour
    {
        private const string Player = "Player";
        [SerializeField] Type type;
        public enum Type
        {
            Default,
            Effect1,
            Effect2,
            Effect3
        }
        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Player)) return;
            Destroy(gameObject);
            other.transform.parent.GetComponent<Player.Player>().ApplyEffect(type);
        }
    }
}