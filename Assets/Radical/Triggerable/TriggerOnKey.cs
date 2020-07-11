using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Person;
using UnityEngine;

namespace Assets.Radical.Triggerable
{
    [RequireComponent(typeof(TriggerableObject))]
    public class TriggerOnKey : MonoBehaviour
    {
        private TriggerableObject _triggerableObject;

        public KeyCode TriggerKey;

        private void Awake()
        {
            _triggerableObject = GetComponent<TriggerableObject>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(TriggerKey))
                _triggerableObject.Trigger();

            else if (Input.GetKeyDown(TriggerKey))
                _triggerableObject.Untrigger();
        }
    }
}
