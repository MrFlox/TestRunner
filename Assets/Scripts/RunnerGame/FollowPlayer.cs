using UnityEngine;

namespace RunnerGame
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] Transform playerTransform;
        Vector3 _newPos;
        void Update()
        {
            _newPos = playerTransform.position;
            _newPos.x = 0;
            transform.position = _newPos;
        }
    }
}