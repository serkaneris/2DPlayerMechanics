using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InputController : MonoBehaviour
    {
        public float HorizontalVal { get; private set; }
        public bool IsHorizontalMovement { get; private set; }

        public float VerticalVal { get; private set; }

        public bool IsJumpPress { get; private set; }

        public KeyCode stompKey = KeyCode.Keypad1;
        public KeyCode wallSlideKey = KeyCode.Keypad2;

        public bool IsStompKeyPress { get; private set; }
        public bool IsWallSlideKeyPress { get; private set; }

       
        // Update is called once per frame
        void Update()
        {
            HorizontalVal = Input.GetAxis("Horizontal");
            VerticalVal = Input.GetAxis("Vertical");
            IsJumpPress = Input.GetButtonDown("Jump");
            IsStompKeyPress = Input.GetKeyDown(stompKey);
            IsWallSlideKeyPress = Input.GetKey(wallSlideKey);


            CheckHorizontalMovement();
        }

        private void CheckHorizontalMovement()
        {
            if (HorizontalVal > 0 || HorizontalVal < 0)
                IsHorizontalMovement = true;
            else
                IsHorizontalMovement = false;
        }
    }
}

