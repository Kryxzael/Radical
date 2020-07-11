using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Player;
using UnityEngine;

namespace Assets.Radical.Items
{
    public abstract class Item
    {
        public Sprite UISprite { get; }

        public Item(Sprite uiSprite)
        {
            UISprite = uiSprite;
        }

        public abstract void OnActivated(ItemHolder user);
    }
}
