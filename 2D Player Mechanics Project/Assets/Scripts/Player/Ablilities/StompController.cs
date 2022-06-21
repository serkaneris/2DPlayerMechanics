using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.Abilities
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class StompController : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Rigidbody2D _rigidbody;

        public bool canStomp = true;
        public float stompGravityScale = 40;

        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
            
        }

        void Update()
        {
            Stomp();
        }

        private void Stomp()
        {
            if (canStomp)
            {
                if (!_playerStates.IsBottomCollision && _playerStates.IsStompKeyPress)
                {
                    _rigidbody.gravityScale = stompGravityScale;
                }
            }
        }

    }
}

