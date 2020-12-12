using Player.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(WallSlideController))]
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(SurroundController))]
    [RequireComponent(typeof(Animator))]
    public class AnimationManager : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private WallSlideController _wallSlideController;
        private InputController _inputController;
        private SurroundController _surroundController;
        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _wallSlideController = GetComponent<WallSlideController>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimations();

        }

        private void UpdateAnimations()
        {
            _animator.SetBool("isWallSliding", _wallSlideController.IsWallSliding());
            _animator.SetBool("isHorizontalMovement", _inputController.IsHorizontalMovement);
            _animator.SetBool("isGrounded", _surroundController.IsGrounded);
            _animator.SetFloat("yVelocity", _rigidbody.velocity.y);
        }
    }
}

