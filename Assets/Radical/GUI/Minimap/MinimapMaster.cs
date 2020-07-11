using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.GUI.Minimap
{
    [RequireComponent(typeof(RectTransform))]
    public class MinimapMaster : MonoBehaviour
    {
        new private RectTransform transform;

        public MappableArea Area;

        private void Awake()
        {
            transform = GetComponent<RectTransform>();
        }

        public Vector2 WorldToMinimapPoint(Vector3 world)
        {
            float x, z;

            //Calculate percentage based coordinates
            x = Area.WorldToLocal(world).x / Area.Size.x;
            z = Area.WorldToLocal(world).z / Area.Size.z;

            //Upscale to minimap size
            x *= transform.rect.width;
            z *= transform.rect.height;

            return new Vector2(x, z);
        }
    }
}
