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

        public Transform wallCheckTransform;
        public float wallCheckDistance = 0.4f;

        public bool IsGrounded;
        public bool IsTouchingWall;


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
            IsTouchingWall = Physics2D.Raycast(wallCheckTransform.position, transform.right, wallCheckDistance, whatIsGroundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
            Gizmos.DrawLine(wallCheckTransform.position, new Vector3(wallCheckTransform.position.x + wallCheckDistance, wallCheckTransform.position.y, wallCheckTransform.position.z));
        }
    }
}

