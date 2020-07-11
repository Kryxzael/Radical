using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Radical.General;
using Assets.Radical.Management;
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
        private Renderer _renderer;
        private DirectionManager _directionManager;
        private GameManager _gameManager;

        public bool IsInvincible;

        [Header("Movement")]
        public float MoveSpeed;
        public float JumpHeight;

        [Header("Power ups")]
        public bool Boosting;
        public float BoostSpeedMultiplier = 1.5f;
        public float BoostDuration = 2f;
        public bool HasShield;

        [Header("Animations")]
        public TwosidedSpriteAnimation IdleAnimation;
        public TwosidedSpriteAnimation WalkAnimation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _renderer = GetComponent<Renderer>();
            _directionManager = GetComponent<DirectionManager>();

            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if (_gameManager.IsGameRunning)
            {
                HandleMoveInput();
                UpdateAnimation();
            }
        }

        /// <summary>
        /// Performs movement logic
        /// </summary>
        private void HandleMoveInput()
        {
            //Horizontal movement
            _rigidbody.velocity = new Vector3(
                x: Input.GetAxisRaw(MOVE_AXIS_HORIZONTAL) * MoveSpeed * (Boosting ? BoostSpeedMultiplier : 1f),
                y: _rigidbody.velocity.y,
                z: Input.GetAxisRaw(MOVE_AXIS_VERTICAL) * MoveSpeed * (Boosting ? BoostSpeedMultiplier : 1f)
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

        /// <summary>
        /// Temporarily increases the speed of the player
        /// </summary>
        public void ActivateSpeedBoost()
        {
            StartCoroutine(speedBoost());

            IEnumerator speedBoost()
            {
                Boosting = true;
                yield return new WaitForSeconds(BoostDuration);
                Boosting = false;
            }
        }

        public void GrantInvincibilityFrames(float time)
        {
            StartCoroutine(CoInvincibilityFrames());

            IEnumerator CoInvincibilityFrames()
            {
                IsInvincible = true;

                DateTime targetTime = DateTime.Now.AddSeconds(time);

                while (DateTime.Now < targetTime)
                {
                    _renderer.enabled = false;
                    yield return new WaitForEndOfFrame();
                    _renderer.enabled = true;
                    yield return new WaitForEndOfFrame();
                }

                IsInvincible = false;
            }
        }
    }
}
