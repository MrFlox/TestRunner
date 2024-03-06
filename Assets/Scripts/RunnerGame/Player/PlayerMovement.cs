using System;
using System.Collections;
using Shared;
using UnityEngine;
using VContainer;

namespace RunnerGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]  private float SideAnimationTime = 0.05f;
        [SerializeField] protected float speed = 15;
        [SerializeField] float jumpPower = 7;
        [SerializeField] Transform bottomCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float sideMove = 3;
        internal Vector3 MovingVelocity;
        private Rigidbody _rigidbody;
        private IInputController _inputController;
        private readonly Vector3 _jumpVector = new(0, 1f, .2f);

        [Inject]
        private void Construct(IInputController inputController) => _inputController = inputController;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            MovingVelocity = new(0, 0, speed);
            _inputController.Start(OnInputMovementHandler);
        }
        private void FixedUpdate() => MoveForward();
        private void OnInputMovementHandler(SwipeDirection movement)
        {
            switch (movement)
            {
                case SwipeDirection.Left:
                    MoveLeft();
                    break;
                case SwipeDirection.Right:
                    MoveRight();
                    break;
                case SwipeDirection.Top:
                    Jump();
                    break;
                case SwipeDirection.Bottom:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movement), movement, null);
            }
        }
        private void Move(float sideOffset)
        {
            var position = transform.position;
            position.x += sideOffset;
            if (IsNotInBounds(position)) return;
            MoveWithAnimation(position.x);
        }
        private void MoveWithAnimation(float newX) => StartCoroutine(MoveWithLerp(newX));
        private void Jump()
        {
            if(!IsGrounded) return;
            _rigidbody.AddForce(_jumpVector * jumpPower, ForceMode.Impulse);
        }
        private  IEnumerator MoveWithLerp(float newX)
        {
            var newPos = transform.position;
            var startTime = Time.time;
            while (Time.time - startTime < SideAnimationTime)
            {
                var t = (Time.time - startTime) / SideAnimationTime;
                newPos.x = Mathf.Lerp(newPos.x, newX, t);
                transform.position = newPos;
                yield return null;
            }
            newPos.x = newX;
            transform.position = newPos;
        }
        private bool IsNotInBounds(Vector3 position) => position.x < -sideMove && position.x > sideMove;
        private void MoveForward()
        {
            if(!IsGrounded) return;
            _rigidbody.velocity = MovingVelocity;
        }
        public void Fly()
        {
            var pos = transform.position;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            pos.y = 2.2f;
            transform.position = pos;
        }
        public void StopFly()
        {
            var pos = transform.position;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            pos.y = 1.2f;
            transform.position = pos;
        }
        private bool IsGrounded => Physics.CheckSphere(bottomCheck.position, .1f, groundLayer);
        private void MoveLeft() => Move(-sideMove);
        private void MoveRight() => Move(sideMove);
        public void Release() => _inputController.Stop(OnInputMovementHandler);
    }
}