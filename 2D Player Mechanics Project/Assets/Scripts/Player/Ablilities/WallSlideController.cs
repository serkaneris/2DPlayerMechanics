using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(SurroundController))]
    public class WallSlideController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private InputController _inputController;
        private SurroundController _surroundController;

        public bool canWallSlide = true;
        public float wallSlideSpeed = 3;
        public float wallSlideTimer = 1f;
        private float _currentWallSlideTimer;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();

            _currentWallSlideTimer = wallSlideTimer;
        }

        // Update is called once per frame
        void Update()
        {
            WallSlide();
            CheckWallSlideStateAndReset();
        }

        private void WallSlide()
        {
            if (IsWallSliding())
            {
                if (_rigidbody.velocity.y < -wallSlideSpeed)
                {
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -wallSlideSpeed);
                }

            }
        }

        public bool IsWallSliding()
        {
            if (canWallSlide)
            {
                if (_inputController.IsWallSlideKeyPress)
                {
                    if (_surroundController.IsTouchingWall && !_surroundController.IsGrounded && _rigidbody.velocity.y < 0 && _currentWallSlideTimer > 0)
                    {
                        _currentWallSlideTimer -= Time.deltaTime;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }

        private void CheckWallSlideStateAndReset()
        {
            if (_surroundController.IsGrounded)
            {
                _currentWallSlideTimer = wallSlideTimer;
            }

            if (!_surroundController.IsTouchingWall)
                _currentWallSlideTimer = wallSlideTimer;
        }

    }
}

