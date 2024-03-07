using UnityEngine;

namespace Shared
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        private Vector3 _newPos;
        private void LateUpdate()
        {
            _newPos = playerTransform.position;
            _newPos.x = 0;
            transform.position = _newPos;
        }
    }
}