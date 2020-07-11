using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.General
{
    [RequireComponent(typeof(SpriteAnimator), typeof(SpriteRenderer))]
    public class DirectionManager : MonoBehaviour
    {
        private SpriteAnimator _animator;
        private SpriteRenderer _renderer;

        private Vector3 _positionLastFrame;

        [Header("Directions")]
        public bool FacingForwards;
        public bool FacingRightwards;

        [Header("Animations")]
        public bool EnableAnimator = true;
        public TwosidedSpriteAnimation Animation;

        private void Awake()
        {
            _animator = GetComponent<SpriteAnimator>();
            _renderer = GetComponent<SpriteRenderer>();

            _positionLastFrame = transform.position;
        }

        private void Update()
        {
            //Refacing
            if (transform.position.z > _positionLastFrame.z)
                FacingForwards = false;

            else if (transform.position.z < _positionLastFrame.z)
                FacingForwards = true;


            if (transform.position.x > _positionLastFrame.x)
                FacingRightwards = true;

            else if (transform.position.x < _positionLastFrame.x)
                FacingRightwards = false;

            if (EnableAnimator && Animation != null)
            {
                _animator.Animation = FacingForwards ? Animation.Front : Animation.Back;
                _renderer.flipX = !FacingRightwards;
            }

            _positionLastFrame = transform.position;
        }
    }
}
