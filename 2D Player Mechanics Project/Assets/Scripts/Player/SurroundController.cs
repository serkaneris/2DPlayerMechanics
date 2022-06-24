using GlobalTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerStates))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class SurroundController : MonoBehaviour
    {
        private PlayerStates _playerStates;
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        public float gravityScale = 4;

        [Header("For Collision Check")]
        public LayerMask LevelGeometryLayer;
        public Transform topChecker;
        public Transform bottomChecker;
        public float topBottomCheckRadius = 0.6f;

        
        public Transform sideTopChecker;
        public Transform sideMidChecker;
        //public Transform sideBottomCheckTransform;
        public float sideCheckDistance = 0.8f;

        
        


        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _rigidbody.gravityScale = gravityScale;
        }

        void Update()
        {
            TopBottomCollisions();
            SideCollisions();
            CheckResetStates();
        }

        private void TopBottomCollisions()
        {
            Collider2D collider2DBottom = Physics2D.OverlapCircle(bottomChecker.position, topBottomCheckRadius, LevelGeometryLayer);
            _playerStates.IsBottomCollision = collider2DBottom;
            if(_playerStates.IsBottomCollision)
            {
                _playerStates.GroundType = DetermineGroundType(collider2DBottom);
            }
            else
            {
                 _playerStates.GroundType = GroundType.None;
            }
            _playerStates.IsTopCollision = Physics2D.OverlapCircle(topChecker.position, topBottomCheckRadius, LevelGeometryLayer);
        }

        private void SideCollisions()
        {
            _playerStates.IsSideTopCollision = Physics2D.Raycast(sideTopChecker.position, transform.right, sideCheckDistance, LevelGeometryLayer);
            _playerStates.IsSideMidCollision = Physics2D.Raycast(sideMidChecker.position, transform.right, sideCheckDistance, LevelGeometryLayer);
            //isSideBottomCollision = Physics2D.Raycast(sideBottomCheckTransform.position, transform.right, sideCheckDistance, LevelGeometryLayer);

           
        }

       

        private void CheckResetStates()
        {
            if (_playerStates.IsBottomCollision)
            {
                _rigidbody.gravityScale = gravityScale;
            }
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(bottomChecker.position, topBottomCheckRadius);
            Gizmos.DrawWireSphere(topChecker.position, topBottomCheckRadius);

            Gizmos.DrawLine(sideTopChecker.position, new Vector3(sideTopChecker.position.x + sideCheckDistance, sideTopChecker.position.y, sideTopChecker.position.z));
            Gizmos.DrawLine(sideMidChecker.position, new Vector3(sideMidChecker.position.x + sideCheckDistance, sideMidChecker.position.y, sideMidChecker.position.z));
            //Gizmos.DrawLine(sideBottomCheckTransform.position, new Vector3(sideBottomCheckTransform.position.x + sideCheckDistance, sideBottomCheckTransform.position.y, sideBottomCheckTransform.position.z));
        }

        private GroundType DetermineGroundType(Collider2D collider)
        {
            if (collider.GetComponent<GroundEffector>())
            {
                GroundEffector groundEffector = collider.GetComponent<GroundEffector>();
                return groundEffector.groundType;
            }
            else
            {
                return GroundType.LevelGeometry;
            }
        }
    }
}

