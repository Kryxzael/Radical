using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Items
{
    public abstract class ItemPickup : MonoBehaviour
    {
        public abstract Item Item { get; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ItemHolder>() is ItemHolder holder)
            {
                holder.HeldItem = Item;
                Destroy(gameObject);
            }
        }
    }
}
