using UnityEngine;

namespace RunnerGame
{
    public class Coin : MonoBehaviour
    {
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
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                other.transform.parent.GetComponent<Player>().ApplyEffect(type);
            }
        }
    }
}