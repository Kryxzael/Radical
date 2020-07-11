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
        public override Item CreateItem(Sprite sprite)
        {
            return new Soda(sprite);
        }

        public class Soda : Item
        {
            public Soda(Sprite uiSprite) : base(uiSprite)
            { }

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
