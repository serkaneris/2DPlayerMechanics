using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class MovementController : MonoBehaviour
    {
        private PlayerStates _playerStates;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        

        //player ability toggles
        public float speed = 10f;
        public float dashSpeed = 100f;
        public float crouchMoveSpeed = 5f;



        //For Creeping and Ducking 
        private CapsuleCollider2D _capsuleCollider;
        private Vector2 _originalColliderOffset;
        private Vector2 _originalColliderSize;

        


        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _capsuleCollider = GetComponent<CapsuleCollider2D>();
            _originalColliderOffset = _capsuleCollider.offset;
            _originalColliderSize = _capsuleCollider.size;
           
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
                if (_playerStates.IsCrouching)
                {
                    _rigidbody.velocity = new Vector2(_playerStates.XInputVal * crouchMoveSpeed, _rigidbody.velocity.y);

                    if (Mathf.Abs(_playerStates.XInputVal) > 0f)
                    {
                        _playerStates.IsCrouchMoving = true;
                        _playerStates.IsRunning = false;
                    }
                    else
                        _playerStates.IsCrouchMoving = false; 
                }
                else
                {
                    _rigidbody.velocity = new Vector2(_playerStates.XInputVal * speed, _rigidbody.velocity.y);
                }


                //if (_playerStates.IsDashKeyPress)
                //{
                //    Debug.Log("Dash!!");
                //    _rigidbody.velocity = new Vector2(_playerStates.XInputVal * dashSpeed, _rigidbody.velocity.y);
                //}

            }
        }

        //private void LedgeClimbing()
        //{
        //    if (!isLedgeDetected && !_playerStates.IsSideTopCollision && _playerStates.IsSideMidCollision)
        //    {
        //        climbTargetPos = new Vector3(transform.position.x + 0.83f, transform.position.y + 1.2f, transform.position.z);
        //        isLedgeDetected = true;
        //        _animator.SetBool("isLedgeClimbing", true);
        //        //transform.position = new Vector3(transform.position.x + 0.83f, transform.position.y + 1.2f, transform.position.z);
        //    }
        //    else
        //    {

        //        isLedgeDetected = false;
        //    }
        //}
        //public void FinishLedgeClimbing()
        //{
        //    isLedgeDetected = false;
        //    _animator.SetBool("isLedgeClimbing", false);
        //    transform.position = climbTargetPos;
        //}

        private void Crouching()
        {
            if(_playerStates.IsBottomCollision && _playerStates.YInputVal < 0f)
            {
                if(!_playerStates.IsCrouching && !_playerStates.IsCrouchMoving)
                {
                    
                    _capsuleCollider.offset = new Vector2(_capsuleCollider.offset.x, -0.5f);
                    _capsuleCollider.size = new Vector2(_capsuleCollider.size.x, 0.9f);
                    
                    _playerStates.IsCrouching = true;
                  
                }
            }
            else if((_playerStates.IsCrouching || _playerStates.IsCrouchMoving) && !_playerStates.IsTopCollision)
            {
                _capsuleCollider.offset = _originalColliderOffset;
                _capsuleCollider.size = _originalColliderSize;
                
                _playerStates.IsCrouching = false;
                _playerStates.IsCrouchMoving = false;
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
            //todo: yukari tusu basili iken runnig olmuyor
            if (Mathf.Abs(_rigidbody.velocity.x) > 0f && _rigidbody.velocity.y < 0.01f && _playerStates.IsBottomCollision && !_playerStates.IsCrouching)
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

