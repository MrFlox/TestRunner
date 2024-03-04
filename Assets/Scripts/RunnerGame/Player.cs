using System;
using Shared;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

namespace RunnerGame
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Swiper))]
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] float speed = 15;
        [SerializeField] float jumpPower = 7;
        [SerializeField] Transform bottomCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float sideMove = 3;
        Rigidbody physics;
        Swiper _swiper;

        [SerializeField] InputAction move;

        void Awake()
        {
            Application.targetFrameRate = 60;
            physics = GetComponent<Rigidbody>();
            _swiper = GetComponent<Swiper>();
            _swiper.OnSwipe += OnSwipeHandler;
        }
        void OnSwipeHandler(Vector2 direction)
        {
            if(direction == Vector2.left) MoveLeft();
            if(direction == Vector2.right) MoveRight();
            if(direction == Vector2.up) Jump();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                MoveLeft();
            if (Input.GetKeyDown(KeyCode.D))
                MoveRight();
            if (Input.GetKeyDown(KeyCode.Space))
                if(IsGrounded)
                    Jump();
        }

        void FixedUpdate()
        {
            if(IsGrounded)
                physics.velocity = new Vector3(0, 0, 8);
        }

        bool IsGrounded => Physics.CheckSphere(bottomCheck.position, .1f, groundLayer);
        void Jump()
        {
            var jumpVector = new Vector3(0, 1, .5f);
            physics.AddForce(jumpVector * jumpPower, ForceMode.Impulse);
            // physics.velocity = new Vector3(0, 10, 8);
        }
        void MoveRight()
        {
            var position = transform.position;
            position.x += sideMove;
            if (position.x <= sideMove)
                transform.position = position;
        }
        void MoveLeft()
        {
            var position = transform.position;
            position.x -= sideMove;
            if (position.x >= -sideMove)
                transform.position = position;
        }
    }
}