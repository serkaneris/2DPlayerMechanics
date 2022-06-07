using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(SurroundController))]
    public class MovementController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private InputController _inputController;
        private SurroundController _surroundController;
        private PlayerStates _playerStates;

        //player ability toggles
        public float speed = 10;



        //player state variables
        public bool facingRight = true;




        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();
            _playerStates = GetComponent<PlayerStates>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Move();
            Flip();
        }
       
        private void Move()
        {
            if(!_surroundController.isSideBottomCollision && !_surroundController.isSideMidCollision &&  !_surroundController.isSideTopCollision)
                _rigidbody.velocity = new Vector2(_inputController.HorizontalVal * speed, _rigidbody.velocity.y);
        }
        
        private void Flip()
        {
            if ((_inputController.HorizontalVal > 0 && !facingRight) || (_inputController.HorizontalVal < 0 && facingRight))
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = !facingRight;
            }
        }
       

    }
}

