using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class FlapController : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Rigidbody2D _rigidbody;

        public float flapForce = 20;
        public int flapAmount = 1;
        private int remainingFlapAmount;

        // Start is called before the first frame update
        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
            

            remainingFlapAmount = flapAmount;
        }

        // Update is called once per frame
        void Update()
        {
            Flap();
            CheckFlapStateAndReset();
        }

        private void Flap()
        {
            if (_playerStates.IsJumpPressed)
            {
                if (!_playerStates.IsBottomCollision)
                {
                    if (remainingFlapAmount > 0)
                    {
                        print("Apply Flap");
                        _rigidbody.velocity = Vector2.up * flapForce;
                        remainingFlapAmount -= 1;
                    }
                }
            }
        }

        private void CheckFlapStateAndReset()
        {
            if (_playerStates.IsBottomCollision)
                remainingFlapAmount = flapAmount;
        }

    }

}

