using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Management;
using Assets.Radical.Triggerable;
using UnityEngine;

namespace Assets.Radical.Person
{
    public class PersonProvideScore : TriggerableComponent
    {
        public int ScoreModifier;

        public override void OnTriggered()
        {
            if (IsTriggered)
                return;

            base.OnTriggered();
            FindObjectOfType<GameManager>().ProvidePoints(ScoreModifier, transform.position + Vector3.up * 1.5f);
        }
    }
}
