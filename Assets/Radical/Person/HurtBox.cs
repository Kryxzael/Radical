using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Management;
using Assets.Radical.Player;
using Assets.Radical.Triggerable;
using UnityEngine;

namespace Assets.Radical.Person
{
    public class HurtBox : TriggerableComponent
    {
        public const float BREAK_SHIELD_IFRAMES = 2f;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
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
