using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.GUI.Minimap
{
    public class MappableArea : MonoBehaviour
    {
        public Vector3 Size;

        public Vector3 WorldToLocal(Vector3 world)
        {
            return world - transform.position;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position + Size * 0.5f, Size);
        }
    }
}
