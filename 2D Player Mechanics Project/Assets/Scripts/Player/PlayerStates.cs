using GlobalTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStates : MonoBehaviour
{

    [field: Header("---PLAYER STATES ---")]
    [field: SerializeField] public bool IsRunning { get; set; }
    [field: SerializeField] public bool IsFacingRight { get; set; } = true;
    [field: SerializeField] public bool IsDucking { get; set; }
    [field: SerializeField] public bool IsCreeping { get; set; }
    //[field: SerializeField] public bool IsInAir { get; set; }
    //[field: SerializeField] public bool IsGrounded { get; set; }
    //[field: SerializeField] public bool IsJumping { get; set; }
    //[field: SerializeField] public bool IsWallJump { get; set; }
    //[field: SerializeField] public bool IsGliding { get; set; }
    //[field: SerializeField] public bool IsStomping { get; set; }

    [field: Header("--- INPUT VARIABLES ---")]
    [field: SerializeField] public bool IsStompKeyPress { get; set; }
    [field: SerializeField] public bool IsDashKeyPress { get; set; }
    [field: SerializeField] public bool IsJumpPressed { get; set; }
    [field: SerializeField] public float XInputVal { get; set; }
    [field: SerializeField] public float YInputVal { get; set; }




    [field: Header("--- COLLISIONS ---")]
    [field: SerializeField] public bool IsTopCollision { get; set; }
    [field: SerializeField] public bool IsSideMidCollision { get; set; }
    [field: SerializeField] public bool IsBottomCollision { get; set; }
    [field: SerializeField] public GroundType GroundType { get; set; }


    //public bool isGrounded;
    
    //public bool isJumping;

    

    //public bool isFacingRight = true;
    //public bool isDucking = false;
    //public bool isCreeping = false;

    //public bool isInAir = false;
    //public bool isWallJump = false;
    //public bool isGliding = false;
    //public bool isStomping = false;

   
}
