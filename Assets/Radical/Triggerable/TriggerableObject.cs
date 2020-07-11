using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Triggerable;
using UnityEngine;

namespace Assets.Radical.Person
{
    public class TriggerableObject : MonoBehaviour
    {
        private const string ON_TRIGGERED_METHOD_NAME = "OnTriggered";
        private const string ON_UNTRIGGERED_METHOD_NAME = "OnUntriggered";

        public bool IsTriggered;

        public void Trigger()
        {
            IsTriggered = true;
            BroadcastMessage(ON_TRIGGERED_METHOD_NAME);

            GetComponents<TriggerableComponent>();
        }

        public void Untrigger()
        {
            IsTriggered = false;
            BroadcastMessage(ON_UNTRIGGERED_METHOD_NAME);
        }
    }
}
