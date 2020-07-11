using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Items
{
    public class ItemHolder : MonoBehaviour
    {
        public Item HeldItem;

        private void Update()
        {
            if (Input.GetButtonDown("UseItem"))
            {
                if (HeldItem != null)
                    HeldItem.OnActivated(this);

                HeldItem = null;
            }
        }
    }
}
