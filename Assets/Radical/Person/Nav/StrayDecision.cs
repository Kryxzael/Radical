using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Person.Nav
{
    public class StrayDecision : NavigationDecision
    {
        public NavChasePlayer Source { get; }
        public PatrolPoint Target { get; }
        public float PatrolRadius { get; }

        public StrayDecision(NavChasePlayer source, PatrolPoint target, float patrolRadius)
        {
            Source = source;
            Target = target;
            PatrolRadius = patrolRadius;
        }

        public override Vector3 GetTarget()
        {
            return Target.transform.position;
        }

        public override bool ShouldBreakFromDecision()
        {
            return Vector3.Distance(Source.transform.position, Target.transform.position) < PatrolRadius;
                
        }

        public override string ToString()
        {
            return Target.PointName;
        }
    }
}
