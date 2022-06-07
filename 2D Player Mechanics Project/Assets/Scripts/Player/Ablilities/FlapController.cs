using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Abilities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(SurroundController))]
    public class FlapController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private InputController _inputController;
        private SurroundController _surroundController;

        public float flapForce = 20;
        public int flapAmount = 1;
        private int remainingFlapAmount;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputController = GetComponent<InputController>();
            _surroundController = GetComponent<SurroundController>();
            

            remainingFlapAmount = flapAmount;
        }

        // Update is called once per frame
        void Update()
        {
            Flap();
            CheckFlapStateAndReset();
        }

        private void Flap()
        {
            if (_inputController.IsJumpPress)
            {
                if (!_surroundController.isBottomCollision)
                {
                    if (remainingFlapAmount > 0)
                    {
                        print("Apply Flap");
                        _rigidbody.velocity = Vector2.up * flapForce;
                        remainingFlapAmount -= 1;
                    }
                }
            }
        }

        private void CheckFlapStateAndReset()
        {
            if (_surroundController.isBottomCollision)
                remainingFlapAmount = flapAmount;
        }

    }

}

