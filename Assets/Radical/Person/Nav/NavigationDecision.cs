using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Person.Nav
{
    public abstract class NavigationDecision
    {
        public abstract Vector3 GetTarget();

        public abstract bool ShouldBreakFromDecision();
    }
}
