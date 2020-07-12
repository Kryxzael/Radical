using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Person.Nav
{
    public class PatrolPoint : MonoBehaviour
    {
        [Range(0f, 1f)]
        public float ChanceToSelect = 1f;

        public string PointName;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 2);
        }
    }
}
