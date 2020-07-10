using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.General
{
    /// <summary>
    /// Helper functions for physics objects
    /// </summary>
    public static class PhysicsHelper
    {
        /// <summary>
        /// Checks whether the object is grounded
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool OnGround(this Collider collider)
        {
            if (collider == null)
                return false;

            Vector3[] pnts = new[]
            {
                new Vector3(collider.bounds.min.x, collider.bounds.min.y + 0.01f, collider.bounds.min.z),
                new Vector3(collider.bounds.min.x, collider.bounds.min.y + 0.01f, collider.bounds.max.z),
                new Vector3(collider.bounds.max.x, collider.bounds.min.y + 0.01f, collider.bounds.min.z),
                new Vector3(collider.bounds.max.x, collider.bounds.min.y + 0.01f, collider.bounds.max.z),
                new Vector3(collider.bounds.center.x, collider.bounds.min.y + 0.01f, collider.bounds.center.z)
            };


            return pnts.Any(i => Physics.RaycastAll(new Ray(i, Vector3.down), 0.1f).Any());
        }
    }
}
