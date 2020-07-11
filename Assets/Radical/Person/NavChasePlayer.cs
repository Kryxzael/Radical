using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Player;
using Assets.Radical.Triggerable;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Radical.Person
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavChasePlayer : TriggerableComponent
    {
        private PlayerController _target;

        private NavMeshAgent _nav;

        private void Awake()
        {
            _target = FindObjectOfType<PlayerController>();
            _nav = GetComponent<NavMeshAgent>();

            _nav.updateRotation = false;
        }

        protected override void UpdateTriggered()
        {
            _nav.SetDestination(_target.transform.position);
        }
    }
}
