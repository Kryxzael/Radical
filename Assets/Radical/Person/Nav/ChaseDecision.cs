using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Person.Nav
{
    public class ChaseDecision : NavigationDecision
    {
        public Transform Target { get; }
        private DateTime TimeToBreakAt { get; }

        public ChaseDecision(Transform target, float chaseDuration)
        {
            Target = target;

            if (float.IsInfinity(chaseDuration))
                TimeToBreakAt = DateTime.MaxValue;
            else
                TimeToBreakAt = DateTime.Now.AddSeconds(chaseDuration);
        }

        public override Vector3 GetTarget()
        {
            return Target.position;
        }

        public override bool ShouldBreakFromDecision()
        {
            return DateTime.Now >= TimeToBreakAt;
        }

        public override string ToString()
        {
            return "Chasing";
        }
    }
}
