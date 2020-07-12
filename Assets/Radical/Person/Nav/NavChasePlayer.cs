using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Management;
using Assets.Radical.Person.Nav;
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
        private PatrolPoint[] _patrolPoints;
        private PersonSpawner _spawnNext;

        public NavigationDecision CurrentDecision;
        public string CurrentDecisionName;

        [Header("Stun")]
        public float StunTime;
        public bool IsStunned;

        [Header("Chase mode")]
        public float ChaseMinDuration;
        public float ChaseMaxDuration;
        public bool PermanentChaser;

        [Header("Stray mode")]
        public float PatrolPointRadius;


        private void Awake()
        {
            _patrolPoints = FindObjectsOfType<PatrolPoint>();
            _spawnNext = FindObjectOfType<PersonSpawner>();

            _target = FindObjectOfType<PlayerController>();
            _nav = GetComponent<NavMeshAgent>();

            _nav.updateRotation = false;
        }

        public void Stun()
        {
            StartCoroutine(stopStun());

            IEnumerator stopStun()
            {
                IsStunned = true;
                yield return new WaitForSeconds(StunTime);
                IsStunned = false;
            }
        }

        public override void OnTriggered()
        {
            if (IsTriggered)
                return;

            base.OnTriggered();

            Stun();
            _spawnNext.SpawnNew();
        }

        protected override void UpdateTriggered()
        {
            _nav.isStopped = IsStunned;

            if (CurrentDecision?.ShouldBreakFromDecision() != false)
            {
                if (CurrentDecision is ChaseDecision && _patrolPoints.Length != 0 && _patrolPoints.Sum(i => i.ChanceToSelect) > 0f)
                {
                    //Create new stray

                    PatrolPoint candidate;

                    do
                    {
                        candidate = _patrolPoints[UnityEngine.Random.Range(0, _patrolPoints.Length)];
                    } while (UnityEngine.Random.value > candidate.ChanceToSelect);

                    CurrentDecision = new StrayDecision(this, candidate, PatrolPointRadius);
                }
                else
                {
                    //Create new chaser
                    CurrentDecision = new ChaseDecision(_target.transform, UnityEngine.Random.Range(ChaseMinDuration, ChaseMaxDuration));
                }

                CurrentDecisionName = CurrentDecision.ToString();

            }

            _nav.SetDestination(CurrentDecision.GetTarget());
        }
    }
}
