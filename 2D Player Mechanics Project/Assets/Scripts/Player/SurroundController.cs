using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SurroundController : MonoBehaviour
    {
        public LayerMask whatIsGroundLayer;
        public Transform groundCheckTransform;
        public float groundCheckRadius = 0.2f;


        
        
        public Transform wallCheckTransformTop;
        public Transform wallCheckTransformMid;
        public float wallCheckDistance = 0.4f;

        public bool IsGrounded;
        public bool IsTouchingWallMid;
        public bool IsTouchingWallTop;


        void Update()
        {
            GroundTouchControl();
            WallTouchControl();
        }

        private void GroundTouchControl()
        {
            IsGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, whatIsGroundLayer);
        }
        private void WallTouchControl()
        {
            IsTouchingWallMid = Physics2D.Raycast(wallCheckTransformMid.position, transform.right, wallCheckDistance, whatIsGroundLayer);
            IsTouchingWallTop = Physics2D.Raycast(wallCheckTransformTop.position, transform.right, wallCheckDistance, whatIsGroundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
            Gizmos.DrawLine(wallCheckTransformMid.position, new Vector3(wallCheckTransformMid.position.x + wallCheckDistance, wallCheckTransformMid.position.y, wallCheckTransformMid.position.z));
            Gizmos.DrawLine(wallCheckTransformTop.position, new Vector3(wallCheckTransformTop.position.x + wallCheckDistance, wallCheckTransformTop.position.y, wallCheckTransformTop.position.z));
        }
    }
}

