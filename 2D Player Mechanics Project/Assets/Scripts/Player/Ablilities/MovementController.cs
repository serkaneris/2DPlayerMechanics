using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputController))]
    public class MovementController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private InputController _inputController;


        //player ability toggles
        public float speed = 10;


        //player state variables
        public bool facingRight = true;




        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Flip();
        }
       
        private void Move()
        {
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

