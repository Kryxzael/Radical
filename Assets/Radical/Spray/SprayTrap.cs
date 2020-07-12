using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Person;
using Assets.Radical.Person.Nav;
using UnityEngine;

namespace Assets.Radical.Spray
{
    public class SprayTrap : MonoBehaviour
    {
        public float DespawnTime;

        private IEnumerator Start()
        {
            foreach (NavChasePlayer i in FindObjectsOfType<NavChasePlayer>())
                i.CurrentDecision = new DetectSprayDecision(this);

            yield return new WaitForSeconds(DespawnTime);
            Destroy(gameObject);
        }
    }
}
