using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(SurroundController))]
    public class StompController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private InputController _inputController;
        private SurroundController _surroundController;

        public bool canStomp = true;
        public float stompGravityScale = 40;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();
            
        }

        void Update()
        {
            Stomp();
        }

        private void Stomp()
        {
            if (canStomp)
            {
                if (!_surroundController.isBottomCollision && _inputController.IsStompKeyPress)
                {
                    _rigidbody.gravityScale = stompGravityScale;
                }
            }
        }

    }
}

