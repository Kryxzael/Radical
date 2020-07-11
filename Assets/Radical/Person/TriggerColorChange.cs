using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Triggerable;
using UnityEngine;

namespace Assets.Radical.Person
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TriggerColorChange : TriggerableComponent
    {
        public Color UntriggeredColor;
        public Color TriggeredColor;

        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = UntriggeredColor;
        }

        public override void OnTriggered()
        {
            base.OnTriggered();
            _renderer.color = TriggeredColor;
        }

        public override void OnUntriggered()
        {
            base.OnTriggered();
            _renderer.color = UntriggeredColor;
        }
    }
}
