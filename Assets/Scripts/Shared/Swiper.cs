using System;
using UnityEngine;
using UnityEngine.Serialization;
using TouchPhase = UnityEngine.TouchPhase;

namespace Shared
{
    public class Swiper : MonoBehaviour
    {
        public event Action<Vector2> OnSwipe;
        Vector2 _fingerDownPos;
        Vector2 _fingerUpPos;

        [FormerlySerializedAs("detectSwipeAfterRelease")] public bool DetectSwipeAfterRelease;

        public float SWIPE_THRESHOLD = 100f;

        // Update is called once per frame
        void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _fingerUpPos = touch.position;
                    _fingerDownPos = touch.position;
                }

                //Detects Swipe while finger is still moving on screen
                if (touch.phase == TouchPhase.Moved)
                {
                    if (!DetectSwipeAfterRelease)
                    {
                        _fingerDownPos = touch.position;
                        DetectSwipe();
                    }
                }

                //Detects swipe after finger is released from screen
                if (touch.phase == TouchPhase.Ended)
                {
                    _fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }
        }
        void DetectSwipe()
        {
            if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
            {
                Debug.Log("Vertical Swipe Detected!");
                if (_fingerDownPos.y - _fingerUpPos.y > 0)
                    OnSwipe?.Invoke(Vector2.up);
                else if (_fingerDownPos.y - _fingerUpPos.y < 0)
                    OnSwipe?.Invoke(Vector2.down);
                _fingerUpPos = _fingerDownPos;
            }
            else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
            {
                Debug.Log("Horizontal Swipe Detected!");
                if (_fingerDownPos.x - _fingerUpPos.x > 0)
                    OnSwipe?.Invoke(Vector2.right);
                else if (_fingerDownPos.x - _fingerUpPos.x < 0)
                    OnSwipe?.Invoke(Vector2.left);
                _fingerUpPos = _fingerDownPos;
            }
            else
            {
                Debug.Log("No Swipe Detected!");
            }
        }

        float VerticalMoveValue()
        {
            return Mathf.Abs(_fingerDownPos.y - _fingerUpPos.y);
        }

        float HorizontalMoveValue()
        {
            return Mathf.Abs(_fingerDownPos.x - _fingerUpPos.x);
        }
    }
    /*public class Swiper : MonoBehaviour
    {

        [SerializeField] InputAction position;
        [SerializeField] InputAction press;
        [SerializeField] float swipeResistance = 100;
        Vector2 initialPos;
        Vector2 currentPos => position.ReadValue<Vector2>();
        void Awake()
        {
            position.Enable();
            press.Enable();
            press.performed += _ =>  initialPos = currentPos;
            press.canceled += _ => DetectSwipe();
        }
        void DetectSwipe()
        {
            Vector2 delta = currentPos - initialPos;
            Vector2 direction = Vector2.zero;
            if (Mathf.Abs(delta.x) > swipeResistance)
                direction.x = Mathf.Clamp(delta.x, -1, 1);

            if (Mathf.Abs(delta.y) > swipeResistance)
                direction.y = Mathf.Clamp(delta.y, -1, 1);

            if (direction != null && OnSwipe != null)
                OnSwipe.Invoke(direction);
        }
    }*/
}