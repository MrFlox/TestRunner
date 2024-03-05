using UnityEngine;

namespace RunnerGame.LevelItems
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            other.transform.parent.TryGetComponent<Player.Player>(out var player);
            if (player != null) player.GameOver();
        }
    }
}