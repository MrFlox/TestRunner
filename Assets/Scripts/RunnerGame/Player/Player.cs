using System;
using System.Collections;
using RunnerGame.Player.Effects;
using Shared;
using UnityEngine;
using VContainer;

namespace RunnerGame.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        const float SideAnimationTime = 0.05f;
        [SerializeField] protected float speed = 15;
        [SerializeField] float jumpPower = 7;
        [SerializeField] Transform bottomCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float sideMove = 3;
        private ScoreManager _scoreManager;
        private Rigidbody _rigidbody;
        internal Vector3 movingVelocity;
        private bool _isFlyMode;
        private Game _game;
        private readonly Vector3 jumpVector = new(0, 1f, .2f);
        private IInputController _inputController;
        [Inject] private void Construct(ScoreManager scoreManager, Game game, IInputController inputController)
        {
            _inputController = inputController;
            _scoreManager = scoreManager;
            _game = game;
        }
        private void Awake()
        {
            Application.targetFrameRate = 60;
            _rigidbody = GetComponent<Rigidbody>();
            _inputController.Start(OnInputMovementHandler);
            movingVelocity = new(0, 0, speed);
        }
        private void OnInputMovementHandler(SwipeDirection movement)
        {
            switch (movement)
            {
                case SwipeDirection.Left:
                    Move(-sideMove);
                    break;
                case SwipeDirection.Right:
                    Move(sideMove);
                    break;
                case SwipeDirection.Top:
                    if (IsGrounded)
                        Jump();
                    break;
                case SwipeDirection.Bottom:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movement), movement, null);
            }
        }

        private void FixedUpdate()
        {
            if (IsGrounded)
                _rigidbody.velocity = movingVelocity;
        }
        private bool IsGrounded => Physics.CheckSphere(bottomCheck.position, .1f, groundLayer);
        private void Jump() =>
            _rigidbody.AddForce(jumpVector * jumpPower, ForceMode.Impulse);
        private void Move(float sideOffset)
        {
            var position = transform.position;
            position.x += sideOffset;
            if (IsNotInBounds(position)) return;
            MoveWithAnimation(position.x);
        }
        private void MoveWithAnimation(float newX) => StartCoroutine(MoveWithLerp(newX));
        public void CollectCoin() => _scoreManager.Add();
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
        public void ApplyEffect(CoinEffectSo effect) => effect?.ApplyEffect(this);
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
        public void GameOver()
        {
            _inputController.Stop(OnInputMovementHandler);
            _game.SetState(Game.GameStates.GameOver);
        }
    }
}