using System;
using UnityEngine;

namespace RunnerGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerScript : MonoBehaviour
    {
        Rigidbody physics;

        void Awake()
        {
            physics = GetComponent<Rigidbody>();
        }
        void Update()
        {
            var direction = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.A))
                MoveLeft();
            if (Input.GetKeyDown(KeyCode.D))
                MoveRight();
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
            direction.z = 1;
            physics.AddForce(direction * 15);
        }
        void Jump()
        {
            physics.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
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