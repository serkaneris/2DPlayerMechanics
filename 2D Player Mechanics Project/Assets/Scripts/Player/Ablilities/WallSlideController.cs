using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{

    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class WallSlideController : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Rigidbody2D _rigidbody;

        public bool canWallSlide = true;
        public float wallSlideSpeed = 3;
        public float wallSlideTimer = 1f;
        private float _currentWallSlideTimer;

        // Start is called before the first frame update
        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _currentWallSlideTimer = wallSlideTimer;
        }

        // Update is called once per frame
        void Update()
        {
            if(canWallSlide)
            {
                WallSlide();
                CheckWallSlideStateAndReset();
            }
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
            if (_playerStates.IsSideMidCollision && !_playerStates.IsBottomCollision && _rigidbody.velocity.y < 0 && Mathf.Abs(_playerStates.XInputVal) > 0.5f && _currentWallSlideTimer > 0)
            {
                _currentWallSlideTimer -= Time.deltaTime;
                return true;
            }
            else
                return false;

        }

        private void CheckWallSlideStateAndReset()
        {
            if (_playerStates.IsBottomCollision)
            {
                _currentWallSlideTimer = wallSlideTimer;
            }

            if (!_playerStates.IsSideMidCollision)
                _currentWallSlideTimer = wallSlideTimer;
        }

    }
}

