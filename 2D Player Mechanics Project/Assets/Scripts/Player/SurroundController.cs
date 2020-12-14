using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SurroundController : MonoBehaviour
    {

        private Rigidbody2D _rigidbody;

        public LayerMask whatIsGroundLayer;
        public Transform groundCheckTransform;
        public Transform upGroundCheckTransform;
        public float groundCheckRadius = 0.2f;

        public Transform wallCheckTransformTop;
        public Transform wallCheckTransformMid;
        public Transform wallCheckTransformBottom;
        public float wallCheckDistance = 0.4f;

        public bool IsGrounded;
        public bool IsUpGrounded;
        public bool IsTouchingWallTop;
        public bool IsTouchingWallMid;
        public bool IsTouchingWallBottom;


        public float gravityScale = 4;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _rigidbody.gravityScale = gravityScale;
        }

        void Update()
        {
            GroundTouchControl();
            WallTouchControl();
            ResetStates();
        }

        private void GroundTouchControl()
        {
            IsGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, whatIsGroundLayer);
            IsUpGrounded = Physics2D.OverlapCircle(upGroundCheckTransform.position, groundCheckRadius, whatIsGroundLayer);
        }
        private void WallTouchControl()
        {
            IsTouchingWallTop = Physics2D.Raycast(wallCheckTransformTop.position, transform.right, wallCheckDistance, whatIsGroundLayer);
            IsTouchingWallMid = Physics2D.Raycast(wallCheckTransformMid.position, transform.right, wallCheckDistance, whatIsGroundLayer);
            IsTouchingWallBottom = Physics2D.Raycast(wallCheckTransformBottom.position, transform.right, wallCheckDistance, whatIsGroundLayer);
        }

        private void ResetStates()
        {
            if (IsGrounded)
            {
                _rigidbody.gravityScale = gravityScale;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
            Gizmos.DrawWireSphere(upGroundCheckTransform.position, groundCheckRadius);

            Gizmos.DrawLine(wallCheckTransformTop.position, new Vector3(wallCheckTransformTop.position.x + wallCheckDistance, wallCheckTransformTop.position.y, wallCheckTransformTop.position.z));
            Gizmos.DrawLine(wallCheckTransformMid.position, new Vector3(wallCheckTransformMid.position.x + wallCheckDistance, wallCheckTransformMid.position.y, wallCheckTransformMid.position.z));
            Gizmos.DrawLine(wallCheckTransformBottom.position, new Vector3(wallCheckTransformBottom.position.x + wallCheckDistance, wallCheckTransformBottom.position.y, wallCheckTransformBottom.position.z));
        }
    }
}

