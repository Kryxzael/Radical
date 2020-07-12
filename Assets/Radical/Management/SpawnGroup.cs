using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Management
{
    [CreateAssetMenu(menuName = "Spawn Group", fileName = "New Spawn Group")]
    public class SpawnGroup : ScriptableObject
    {
        public int Threshold;
        public GameObject Prefab;
    }
}
