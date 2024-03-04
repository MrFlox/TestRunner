using System;
using Shared;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace RunnerGame
{
    [RequireComponent(typeof(Rigidbody))]

    public class Player : MonoBehaviour
    {
        [SerializeField] Swiper _swiper;
        [SerializeField] float speed = 15;
        [SerializeField] float jumpPower = 7;
        [SerializeField] Transform bottomCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float sideMove = 3;
        Rigidbody _rigidbody;
        readonly Vector3 jumpVector = new(0, 1, .5f);
        readonly Vector3 movingVelocity = new(0, 0, 8);
        void Awake()
        {
            Application.targetFrameRate = 60;
            _rigidbody = GetComponent<Rigidbody>();
            _swiper.OnSwipe += OnSwipeHandler;
        }
        void OnSwipeHandler(SwipeDirection obj)
        {
            switch (obj)
            {
                case SwipeDirection.Left:
                    MoveLeft();
                    break;
                case SwipeDirection.Right:
                    MoveRight();
                    break;
                case SwipeDirection.Bottom:
                    break;
                case SwipeDirection.Top:
                    Jump();
                    break;
            }
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                MoveLeft();
            if (Input.GetKeyDown(KeyCode.D))
                MoveRight();
            if (Input.GetKeyDown(KeyCode.Space))
                if (IsGrounded)
                    Jump();
        }
        void FixedUpdate()
        {
            if (IsGrounded)
                _rigidbody.velocity = movingVelocity;
        }
        bool IsGrounded => Physics.CheckSphere(bottomCheck.position, .1f, groundLayer);
        void Jump() =>
            _rigidbody.AddForce(jumpVector * jumpPower, ForceMode.Impulse);
        void MoveRight() => Move(sideMove);
        void MoveLeft() => Move(-sideMove);
        void Move(float sideOffset)
        {
            var position = transform.position;
            position.x += sideOffset;
            if (IsNotInBounds(position)) return;
            transform.position = position;
        }
        bool IsNotInBounds(Vector3 position) => position.x < -sideMove && position.x > sideMove;
    }
}