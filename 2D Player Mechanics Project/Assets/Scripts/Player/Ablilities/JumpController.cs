using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(SurroundController))]
    public class JumpController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private InputController _inputController;
        private SurroundController _surroundController;

        public float jumpForce = 16;

        public bool canPowerJump = true;
        public float powerJumpForce = 30;
        
        

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();
        }

        // Update is called once per frame
        void Update()
        {
            Jump();
        }

        private void Jump()
        {
            if (_inputController.IsJumpPress)
            {
                if (_surroundController.isBottomCollision)
                {
                    //power Jump
                    if (canPowerJump && _inputController.VerticalVal < 0)
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

