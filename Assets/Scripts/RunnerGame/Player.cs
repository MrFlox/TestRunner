using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace RunnerGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] float speed = 15;
        [SerializeField] float jumpPower = 7;
        [SerializeField] Transform bottomCheck;
        [SerializeField] LayerMask groundLayer;
        Rigidbody physics;

        void Awake() => physics = GetComponent<Rigidbody>();
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                MoveLeft();
            if (Input.GetKeyDown(KeyCode.D))
                MoveRight();
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
            if(IsGrounded)
                physics.AddForce(Vector3.forward * speed);
        }

        bool IsGrounded => Physics.CheckSphere(bottomCheck.position, .1f, groundLayer);

        void Jump() => physics.AddForce((Vector3.up + Vector3.forward) * jumpPower, ForceMode.Impulse);
        void MoveRight()
        {
            var position = transform.position;
            position.x += 3;
            transform.position = position;
        }
        void MoveLeft()
        {
            var position = transform.position;
            position.x -= 3;
            transform.position = position;
        }
    }
}