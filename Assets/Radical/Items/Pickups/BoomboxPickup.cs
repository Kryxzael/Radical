using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Items.Pickups
{
    public class BoomboxPickup : ItemPickup
    {
        public GameObject BoomboxBlastObject;

        public override Item CreateItem(Sprite sprite)
        {
            return new Boombox(sprite, BoomboxBlastObject);
        }

        public class Boombox : Item
        {
            public GameObject BoomboxBlastObject { get; }

            public Boombox(Sprite uiSprite, GameObject boomboxBlastObject) : base(uiSprite)
            {
                BoomboxBlastObject = boomboxBlastObject;
            }

            public override void OnActivated(ItemHolder user)
            {
                Instantiate(BoomboxBlastObject, user.transform.position, Quaternion.identity);
            }
        }
    }
}
