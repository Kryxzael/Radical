using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Person;
using Assets.Radical.Triggerable;
using UnityEngine;

namespace Assets.Radical.Shockwave
{
    public class ShockwaveTriggerer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TriggerableObject>() is TriggerableObject triggerable)
            {
                triggerable.Trigger();
            }
        }
    }
}
