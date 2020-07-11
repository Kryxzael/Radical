using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Triggerable
{
    public abstract class TriggerableComponent : MonoBehaviour
    {
        public bool IsTriggered;

        public virtual void OnTriggered() 
        {
            IsTriggered = true;
        }

        public virtual void OnUntriggered() 
        {
            IsTriggered = false;
        }

        protected virtual void UpdateUntriggered()
        { }

        protected virtual void UpdateTriggered()
        { }

        protected virtual void Update()
        {
            if (IsTriggered)
            {
                UpdateTriggered();
            }
            else
            {
                OnUntriggered();
            }
        }
    }
}
