using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class GlideController : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Rigidbody2D _rigidbody;

        public bool canGlide = true;
        public float glideAmount = 4f;
        public float gliderTimeForSecond = 2f;
        private float _currentGliderTime;

        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _currentGliderTime = gliderTimeForSecond;
        }

        // Update is called once per frame
        void Update()
        {
            if (canGlide)
            {
                Glide();
                CheckGlideStateAndReset();
            }
            
        }

        private void Glide()
        {

            //süzülme için yere temas olmayacak ve yan temas olmayacak
            //Todo:_playerState.verticalVal yerine rigidbody velocity x kontrol edilebilir!!!
            if (!_playerStates.IsBottomCollision && !_playerStates.IsSideMidCollision && _playerStates.YInputVal > 0.5f && _rigidbody.velocity.y < 0.1f)
            {
                if (_currentGliderTime > 0)
                {
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Sign(_rigidbody.velocity.y) * glideAmount);
                    _currentGliderTime -= Time.deltaTime;
                }

            }
        }

        private void CheckGlideStateAndReset()
        {
            if (_playerStates.IsBottomCollision)
            {
                _currentGliderTime = gliderTimeForSecond; //Glider Timer reset
            }
        }

    }
}