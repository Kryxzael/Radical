using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Player;
using UnityEngine;

namespace Assets.Radical.Items.Types
{
    public class SodaPickup : ItemPickup
    {
        public override Item Item { get; } = new Soda();

        public class Soda : Item
        {
            public override void OnActivated(ItemHolder user)
            {
                if (user.GetComponent<PlayerController>() is PlayerController player)
                {
                    player.ActivateSpeedBoost();
                }
            }
        }
    }
}
