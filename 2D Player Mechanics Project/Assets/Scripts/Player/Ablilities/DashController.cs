using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class DashController : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Rigidbody2D _rigidbody;


        public float dashSpeed = 100f;
        //public float dashTimeForSecond = 0.2f;
        //public float dashCooldownTimeForSecond = 1f;

        //private float _currentDashTime;
        //private float _currentDashCooldownTime;

        public bool canGroundDash;
        public bool canAirDash;

        public bool isAirDashing;
        public bool isGroundDashing;

        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();

            //_currentDashTime = dashTimeForSecond;
        }

        // Update is called once per frame
        void Update()
        {
            Dash();
        }

        void Dash()
        {
            if(canGroundDash)
            {
                if(_playerStates.IsBottomCollision && _playerStates.IsDashKeyPress)
                {
                    Debug.Log("Dash!!");
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * dashSpeed, _rigidbody.velocity.y);
                }
            }
        }
    }

}