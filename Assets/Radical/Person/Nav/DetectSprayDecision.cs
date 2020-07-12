using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Spray;
using UnityEngine;

namespace Assets.Radical.Person.Nav
{
    public class DetectSprayDecision : NavigationDecision
    {
        public SprayTrap Target { get; }

        public DetectSprayDecision(SprayTrap target)
        {
            Target = target;
        }

        public override Vector3 GetTarget()
        {
            return Target.transform.position;
        }

        public override bool ShouldBreakFromDecision()
        {
            return Target == null;
        }
    }
}
