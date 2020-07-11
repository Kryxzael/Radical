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
    [RequireComponent(typeof(SpriteRenderer))]
    public class TriggerColorChange : TriggerableComponent
    {
        public Color UntriggeredColor;
        public Color TriggeredColor;

        [Header("Animation")]
        public TwosidedSpriteAnimation IdleAnimation;
        public TwosidedSpriteAnimation WalkAnimation;

        private SpriteRenderer _renderer;
        private DirectionManager _directionManager;

        private void Awake()
        {
            _directionManager = GetComponent<DirectionManager>();
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = UntriggeredColor;
        }

        protected override void UpdateTriggered()
        {
            base.UpdateTriggered();

            Debug.Log(GetComponent<Rigidbody>().velocity);
        }

        public override void OnTriggered()
        {
            base.OnTriggered();
            _renderer.color = TriggeredColor;
            _directionManager.Animation = WalkAnimation;
        }

        public override void OnUntriggered()
        {
            base.OnTriggered();
            _renderer.color = UntriggeredColor;
            _directionManager.Animation = IdleAnimation;
        }
    }
}
