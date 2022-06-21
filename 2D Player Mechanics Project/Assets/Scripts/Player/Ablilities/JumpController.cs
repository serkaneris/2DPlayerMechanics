using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpController : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Rigidbody2D _rigidbody;
        

        public float jumpForce = 16;

        public bool canPowerJump = true;
        public float powerJumpForce = 30;

        
        

        // Start is called before the first frame update
        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
           
        }

        // Update is called once per frame
        void Update()
        {
            Jump();
            
           
        }

        private void Jump()
        {
            if (_playerStates.IsJumpPressed)
            {
                if (_playerStates.IsBottomCollision)
                {
                    //power Jump
                    if (canPowerJump && _playerStates.YInputVal < 0)
                    {
                        ApplyJump(powerJumpForce);
                    }
                    //Jump
                    else
                    {
                        ApplyJump(jumpForce);
                    }
                }
                
            }
        }

       
        private void ApplyJump(float power)
        {
            
            _rigidbody.velocity = Vector2.up * power;
        }
    }
}

