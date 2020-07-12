using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Items.Pickups
{
    public class SprayCanPickup : ItemPickup
    {
        public GameObject SprayPrefab;

        public override Item CreateItem(Sprite sprite)
        {
            return new SprayCan(sprite, SprayPrefab);
        }

        public class SprayCan : Item
        {
            public GameObject SprayPrefab { get; }

            public SprayCan(Sprite uiSprite, GameObject sprayPrefab) : base(uiSprite)
            {
                SprayPrefab = sprayPrefab;
            }

            public override void OnActivated(ItemHolder user)
            {
                Physics.Raycast(new Ray(user.transform.position + Vector3.up * 1f, Vector3.down), out RaycastHit hit, 10f);
                Instantiate(SprayPrefab, hit.point + Vector3.up * 0.05f, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
