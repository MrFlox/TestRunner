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

        [SerializeField] Swiper _swiper;
        [SerializeField] protected float speed = 15;
        [SerializeField] float jumpPower = 7;
        [SerializeField] Transform bottomCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float sideMove = 3;
        private ScoreManager _scoreManager;
        private Rigidbody _rigidbody;
        readonly Vector3 jumpVector = new(0, 1f, .2f);
        internal Vector3 movingVelocity;
        private bool isFlyMode;

        [Inject] private void Construct(ScoreManager scoreManager) => _scoreManager = scoreManager;
        private void Awake()
        {
            Application.targetFrameRate = 60;
            _rigidbody = GetComponent<Rigidbody>();
            _swiper.OnSwipe += OnSwipeHandler;
            movingVelocity = new(0, 0, speed);
        }
        private void OnSwipeHandler(SwipeDirection obj)
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
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                MoveLeft();
            if (Input.GetKeyDown(KeyCode.D))
                MoveRight();
            if (Input.GetKeyDown(KeyCode.Space))
                if (IsGrounded)
                    Jump();
        }
        private void FixedUpdate()
        {
            if (IsGrounded)
                _rigidbody.velocity = movingVelocity;
        }
        private bool IsGrounded => Physics.CheckSphere(bottomCheck.position, .1f, groundLayer);
        private void Jump() =>
            _rigidbody.AddForce(jumpVector * jumpPower, ForceMode.Impulse);
        private void MoveRight() => Move(sideMove);
        private void MoveLeft() => Move(-sideMove);
        private void Move(float sideOffset)
        {
            var position = transform.position;
            position.x += sideOffset;
            if (IsNotInBounds(position)) return;
            MoveWithAnimation(position.x);
        }
        private void MoveWithAnimation(float newX)
        {
            StartCoroutine(MoveWithLerp(newX));
        }

        public void CollectCoin()
        {
            _scoreManager.Add();
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
    }
}