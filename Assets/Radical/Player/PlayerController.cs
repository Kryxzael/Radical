using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Radical.General;
using UnityEngine;

namespace Assets.Radical.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(DirectionManager))]
    public class PlayerController : MonoBehaviour
    {
        /*
         * Input 
         */
        private const string MOVE_AXIS_HORIZONTAL = "Horizontal";
        private const string MOVE_AXIS_VERTICAL = "Vertical";

        private Rigidbody _rigidbody;
        private Collider _collider;
        private DirectionManager _directionManager;

        [Header("Movement")]
        public float MoveSpeed;
        public float JumpHeight;

        [Header("Animations")]
        public TwosidedSpriteAnimation IdleAnimation;
        public TwosidedSpriteAnimation WalkAnimation;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _directionManager = GetComponent<DirectionManager>();
        }

        private void Update()
        {
            HandleMoveInput();
            UpdateAnimation();
        }

        /// <summary>
        /// Performs movement logic
        /// </summary>
        private void HandleMoveInput()
        {
            //Horizontal movement
            _rigidbody.velocity = new Vector3(
                x: Input.GetAxisRaw(MOVE_AXIS_HORIZONTAL) * MoveSpeed,
                y: _rigidbody.velocity.y,
                z: Input.GetAxisRaw(MOVE_AXIS_VERTICAL) * MoveSpeed
            );

            //Jump
            if (_collider.OnGround() && Input.GetButtonDown("Jump"))
                _rigidbody.velocity += Vector3.up * JumpHeight;
        }

        /// <summary>
        /// Updates the player's current animation
        /// </summary>
        private void UpdateAnimation()
        {
            //Animation
            if (Mathf.Abs(_rigidbody.velocity.x) > 0 || Mathf.Abs(_rigidbody.velocity.z) > 0)
                _directionManager.Animation = WalkAnimation;

            else
                _directionManager.Animation = IdleAnimation;
        }
    }
}
