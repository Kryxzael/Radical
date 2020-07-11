using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Player;
using UnityEngine;

namespace Assets.Radical.Items.Pickups
{
    public class GumPickup : ItemPickup
    {
        public override Item CreateItem(Sprite sprite)
        {
            return new Gum(sprite);
        }

        public class Gum : Item
        {
            public Gum(Sprite uiSprite) : base(uiSprite)
            {  }

            public override void OnActivated(ItemHolder user)
            {
                if (user.GetComponent<PlayerController>() is PlayerController pl)
                {
                    pl.HasShield = true;
                }
            }
        }
    }
}
