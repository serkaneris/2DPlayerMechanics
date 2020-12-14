using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(SurroundController))]
    public class GlideController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private InputController _inputController;
        private SurroundController _surroundController;

        public bool canGlide = true;
        public float glideAmount = 4f;
        public float gliderTimer = 2f;
        private float _currentGliderTimer;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();

            _currentGliderTimer = gliderTimer;
        }

        // Update is called once per frame
        void Update()
        {
            Glide();
            CheckGlideStateAndReset();
        }

        private void Glide()
        {
            if (canGlide)
            {
                if (!_surroundController.IsGrounded && _inputController.VerticalVal > 0.5f && _rigidbody.velocity.y < 0.2f)
                {
                    if (_currentGliderTimer > 0)
                    {
                        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Sign(_rigidbody.velocity.y) * glideAmount);
                        _currentGliderTimer -= Time.deltaTime;
                    }

                }
            }
        }

        private void CheckGlideStateAndReset()
        {
            if (_surroundController.IsGrounded)
            {
                _currentGliderTimer = gliderTimer; //Glider Timer reset
            }
        }

    }
}