using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.General;
using Assets.Radical.Triggerable;
using UnityEngine;

namespace Assets.Radical.Person
{
    [RequireComponent(typeof(DirectionManager))]
    public class PersonAnimator : TriggerableComponent
    {
        private DirectionManager _directionManager;

        public TwosidedSpriteAnimation IdleAnimation;
        public TwosidedSpriteAnimation StunAnimation;
        public TwosidedSpriteAnimation ChaseAnimation;

        private void Awake()
        {
            _directionManager = GetComponent<DirectionManager>();
            _directionManager.Animation = IdleAnimation;
        }

        public override void OnTriggered()
        {
            base.OnTriggered();
            _directionManager.Animation = ChaseAnimation;
        }
    }
}
