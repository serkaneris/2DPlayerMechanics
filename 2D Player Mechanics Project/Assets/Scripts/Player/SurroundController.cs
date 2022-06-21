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

        public float gravityScale = 4;

        [Header("For Collision Check")]
        public LayerMask LevelGeometryLayer;
        public Transform topCheckTransform;
        public Transform bottomCheckTransform;
        public float topBottomCheckRadius = 0.6f;

        
        //public Transform sideTopCheckTransform;
        public Transform sideMidCheckTransform;
        //public Transform sideBottomCheckTransform;
        public float sideCheckDistance = 0.8f;

        





        void Start()
        {
            _playerStates = GetComponent<PlayerStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
            
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
            Collider2D collider2DBottom = Physics2D.OverlapCircle(bottomCheckTransform.position, topBottomCheckRadius, LevelGeometryLayer);
            _playerStates.IsBottomCollision = collider2DBottom;
            if(_playerStates.IsBottomCollision)
            {
                _playerStates.GroundType = DetermineGroundType(collider2DBottom);
            }
            else
            {
                 _playerStates.GroundType = GroundType.None;
            }
            _playerStates.IsTopCollision = Physics2D.OverlapCircle(topCheckTransform.position, topBottomCheckRadius, LevelGeometryLayer);
        }

        private void SideCollisions()
        {
            //isSideTopCollision = Physics2D.Raycast(sideTopCheckTransform.position, transform.right, sideCheckDistance, LevelGeometryLayer);
            _playerStates.IsSideMidCollision = Physics2D.Raycast(sideMidCheckTransform.position, transform.right, sideCheckDistance, LevelGeometryLayer);
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
            Gizmos.DrawWireSphere(bottomCheckTransform.position, topBottomCheckRadius);
            Gizmos.DrawWireSphere(topCheckTransform.position, topBottomCheckRadius);

            //Gizmos.DrawLine(sideTopCheckTransform.position, new Vector3(sideTopCheckTransform.position.x + sideCheckDistance, sideTopCheckTransform.position.y, sideTopCheckTransform.position.z));
            Gizmos.DrawLine(sideMidCheckTransform.position, new Vector3(sideMidCheckTransform.position.x + sideCheckDistance, sideMidCheckTransform.position.y, sideMidCheckTransform.position.z));
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

