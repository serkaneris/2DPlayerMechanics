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
        

        //player ability toggles
        public float speed = 10f;
        public float creepSpeed = 5f;


        //player state variables
        public bool isFacingRight = true;
        public bool isDucking;
        public bool isCreeping;

        //For Creeping and Ducking 
        private CapsuleCollider2D _capsuleCollider;
        private Vector2 _originalColliderSize;
        //TODO: later remove this
        private SpriteRenderer _spriteRenderer;


        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();
           

            _capsuleCollider = GetComponent<CapsuleCollider2D>();
            _originalColliderSize = _capsuleCollider.size;
            _spriteRenderer =  GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Move();
            Flip();
            Crouching();
        }
       
        private void Move()
        {
            if (!_surroundController.isSideMidCollision)
            {
                if (isDucking)
                {
                    _rigidbody.velocity = new Vector2(_inputController.HorizontalVal * creepSpeed, _rigidbody.velocity.y);
                    
                    if(Mathf.Abs(_inputController.HorizontalVal) > 0f)
                        isCreeping = true;
                    else
                        isCreeping = false; 
                }
                else
                {
                    _rigidbody.velocity = new Vector2(_inputController.HorizontalVal * speed, _rigidbody.velocity.y);
                }

            }

            //if (!_surroundController.isSideBottomCollision && !_surroundController.isSideMidCollision && !_surroundController.isSideTopCollision)
            //    _rigidbody.velocity = new Vector2(_inputController.HorizontalVal * speed, _rigidbody.velocity.y);
        }

        private void Crouching()
        {
            if(_surroundController.isBottomCollision && _inputController.VerticalVal < 0f)
            {
                if(!isDucking && !isCreeping)
                {
                    _capsuleCollider.size = new Vector2(_capsuleCollider.size.x, _capsuleCollider.size.y / 2);
                    transform.position = new Vector2(transform.position.x, transform.position.y - (_originalColliderSize.y / 4));
                    isDucking = true;
                    _spriteRenderer.sprite = Resources.Load<Sprite>("ArrowRecSmall");
                }
            }
            else if((isDucking || isCreeping ) && !_surroundController.isTopCollision)
            {
                _capsuleCollider.size = _originalColliderSize;
                transform.position = new Vector2(transform.position.x, transform.position.y + (_originalColliderSize.y / 4));
                _spriteRenderer.sprite = Resources.Load<Sprite>("ArrowRec");
                isDucking = false;
                isCreeping = false;
            }
        }
        
        private void Flip()
        {
            if ((_inputController.HorizontalVal > 0 && !isFacingRight) || (_inputController.HorizontalVal < 0 && isFacingRight))
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingRight = !isFacingRight;
            }
        }
       

    }
}

