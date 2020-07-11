using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class ItemPickup : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public abstract Item CreateItem(Sprite sprite);

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ItemHolder>() is ItemHolder holder)
            {
                holder.HeldItem = CreateItem(_renderer.sprite);
                Destroy(gameObject);
            }
        }
    }
}
