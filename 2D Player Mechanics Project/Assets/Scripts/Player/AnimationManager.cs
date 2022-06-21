using Player.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class AnimationManager : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Animator _animator;
        private Rigidbody2D _rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimations();

        }

        private void UpdateAnimations()
        {
            _animator.SetBool("isRunning", _playerStates.IsRunning);
            _animator.SetBool("isGrounded", _playerStates.IsBottomCollision);
            _animator.SetBool("isWallSliding", _playerStates.IsWallSliding);
            _animator.SetBool("isCrouching", _playerStates.IsCrouching);
            _animator.SetBool("isCrouchMoving", _playerStates.IsCrouchMoving);
            _animator.SetFloat("xVelocity", _rigidbody.velocity.x);
            _animator.SetFloat("yVelocity", _rigidbody.velocity.y);

            ////Grounded
            //if (_surroundController.isBottomCollision)
            //{
            //    //Move
            //    if (Mathf.Abs(_rigidbody.velocity.x) > 0f && _rigidbody.velocity.y < 0.01f)
            //    {
            //        _animator.SetBool("move", true);
            //    }
            //    else if(Mathf.Abs(_rigidbody.velocity.x) < 0.01f && _rigidbody.velocity.y < 0.01f)
            //    {
            //        _animator.SetBool("idle", true);
            //    }

            //}


            //_animator.SetBool("isWallSliding", _wallSlideController.IsWallSliding());
            //_animator.SetBool("isHorizontalMovement", _inputController.IsHorizontalMovement);
            //_animator.SetBool("isBottomCollision", _surroundController.isBottomCollision);
            //_animator.SetFloat("yVelocity", _rigidbody.velocity.y);
        }
    }
}

