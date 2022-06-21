using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        private PlayerStates _playerStates;

        private Rigidbody2D _rigidbody;
       
        

        //player ability toggles
        public float speed = 10f;
        public float dashSpeed = 100f;
        public float creepSpeed = 5f;



        //For Creeping and Ducking 
        private CapsuleCollider2D _capsuleCollider;
        private Vector2 _originalColliderSize;
        //TODO: later remove this
        private SpriteRenderer _spriteRenderer;


        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _capsuleCollider = GetComponent<CapsuleCollider2D>();
            _originalColliderSize = _capsuleCollider.size;
            _spriteRenderer =  GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            CheckRunning();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Move();
            Flip();
            Crouching();
        }
       

        //Todo:Refactoring yapilacak!
        private void Move()
        {
            if (!_playerStates.IsSideMidCollision)
            {
                if (_playerStates.IsDucking)
                {
                    _rigidbody.velocity = new Vector2(_playerStates.XInputVal * creepSpeed, _rigidbody.velocity.y);
                    
                    if(Mathf.Abs(_playerStates.XInputVal) > 0f)
                        _playerStates.IsCreeping = true;
                    else
                        _playerStates.IsCreeping = false; 
                }
                if (_playerStates.IsDashKeyPress)
                {
                    Debug.Log("Dash!!");
                    _rigidbody.velocity = new Vector2(_playerStates.XInputVal * dashSpeed, _rigidbody.velocity.y);
                }
                else
                {
                    _rigidbody.velocity = new Vector2(_playerStates.XInputVal * speed, _rigidbody.velocity.y);
                    

                   
                }

            }
        }

        private void Crouching()
        {
            if(_playerStates.IsBottomCollision && _playerStates.YInputVal < 0f)
            {
                if(!_playerStates.IsDucking && !_playerStates.IsCreeping)
                {
                    _capsuleCollider.size = new Vector2(_capsuleCollider.size.x, _capsuleCollider.size.y / 2);
                    transform.position = new Vector2(transform.position.x, transform.position.y - (_originalColliderSize.y / 4));
                    _playerStates.IsDucking = true;
                    _spriteRenderer.sprite = Resources.Load<Sprite>("Charecter2");
                }
            }
            else if((_playerStates.IsDucking || _playerStates.IsCreeping ) && !_playerStates.IsTopCollision)
            {
                _capsuleCollider.size = _originalColliderSize;
                transform.position = new Vector2(transform.position.x, transform.position.y + (_originalColliderSize.y / 4));
                _spriteRenderer.sprite = Resources.Load<Sprite>("Charecter1");
                _playerStates.IsDucking = false;
                _playerStates.IsCreeping = false;
            }
        }
        
        private void Flip()
        {
            if ((_playerStates.XInputVal > 0 && !_playerStates.IsFacingRight) || (_playerStates.XInputVal < 0 && _playerStates.IsFacingRight))
            {
                transform.Rotate(0f, 180f, 0f);
                _playerStates.IsFacingRight = !_playerStates.IsFacingRight;
            }
        }
       
        private void CheckRunning()
        {
            if (Mathf.Abs(_rigidbody.velocity.x) > 0f && _rigidbody.velocity.y < 0.01f)
            {
                _playerStates.IsRunning = true;
            }
            else
            {
                _playerStates.IsRunning = false;
            }
        }
    }
}

