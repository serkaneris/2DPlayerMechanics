using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerStates))]
    public class InputController : MonoBehaviour
    {


        private PlayerStates _playerStates;

        

        public bool IsJumpPress { get; private set; }

        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode stompKey = KeyCode.Keypad1;
        public KeyCode dashKey = KeyCode.LeftShift;
        //public KeyCode glideKey = KeyCode.Mouse1;
        //public KeyCode wallSlideKey = KeyCode.Mouse1; //Wall slide key changed by right left key

        

        private void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
        }

        // Update is called once per frame
        void Update()
        {
            _playerStates.XInputVal = Input.GetAxis("Horizontal");
            _playerStates.YInputVal = Input.GetAxis("Vertical");
            _playerStates.IsJumpPressed = Input.GetButtonDown("Jump") || Input.GetKeyDown(jumpKey);
            _playerStates.IsStompKeyPress = Input.GetKeyDown(stompKey);
            _playerStates.IsDashKeyPress = Input.GetKey(dashKey);
            //isGlideKeyPress = Input.GetKey(glideKey);
            //IsWallSlideKeyPress = Input.GetKey(wallSlideKey);


           
        }

        
    }
}

