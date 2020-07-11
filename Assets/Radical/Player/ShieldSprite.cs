using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Player
{
    [RequireComponent(typeof(SpriteAnimator))]
    public class ShieldSprite : MonoBehaviour
    {
        private SpriteAnimator _animator;

        public SpriteAnimation ShieldAnimation;
        public PlayerController Source;

        private void Awake()
        {
            _animator = GetComponent<SpriteAnimator>();
        }

        private void Update()
        {
            if (Source.HasShield)
                _animator.Animation = ShieldAnimation;

            else
                _animator.Animation = null;
        }
    }
}
