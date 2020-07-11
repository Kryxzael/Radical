using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Management;
using Assets.Radical.Player;
using Assets.Radical.Triggerable;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Radical.Person
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavChasePlayer : TriggerableComponent
    {
        public const float BREAK_SHIELD_IFRAMES = 2f;


        private PlayerController _target;
        private GameManager _gameManager;

        private NavMeshAgent _nav;

        private void Awake()
        {
            _target = FindObjectOfType<PlayerController>();
            _gameManager = FindObjectOfType<GameManager>();

            _nav = GetComponent<NavMeshAgent>();

            _nav.updateRotation = false;
        }

        protected override void UpdateTriggered()
        {
            _nav.SetDestination(_target.transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsTriggered && other.GetComponent<PlayerController>() is PlayerController pl)
            {
                if (pl.IsInvincible)
                    return;

                if (pl.HasShield)
                {
                    pl.HasShield = false;
                    pl.GrantInvincibilityFrames(BREAK_SHIELD_IFRAMES);
                    return;
                }


                _gameManager.GameOver();
            }
                
        }
    }
}
