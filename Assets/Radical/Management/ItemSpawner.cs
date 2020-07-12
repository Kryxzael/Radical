using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Items;
using Assets.Radical.Person.Nav;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Assets.Radical.Management
{
    public class ItemSpawner : MonoBehaviour
    {
        private PatrolPoint[] _spawnPoints;

        [Header("Spawning")]
        public ItemPickup[] Items = new ItemPickup[0];
        public int InitalSpawnAmount;
        public float YOffset = 0.5f;

        [Header("Wait time")]
        public float MinSpawnWaitTime;
        public float MaxSpawnWaitTime;

        private void Awake()
        {
            _spawnPoints = FindObjectsOfType<PatrolPoint>();
        }

        private void Start()
        {
            for (int i = 0; i < InitalSpawnAmount; i++)
            {
                SpawnNew();
            }

            Invoke(nameof(Cycle), Random.Range(MinSpawnWaitTime, MaxSpawnWaitTime));
        }

        private void Cycle()
        {
            SpawnNew();
            Invoke(nameof(Cycle), Random.Range(MinSpawnWaitTime, MaxSpawnWaitTime));
        }

        public void SpawnNew()
        {
            if (Items.Length == 0)
                throw new System.InvalidOperationException("No items registered in item spawner");

            ItemPickup candidateItem = Items[Random.Range(0, Items.Length)];

            if (_spawnPoints.Length == 0 || _spawnPoints.Sum(i => i.ChanceToSelect) <= 0)
                throw new System.InvalidOperationException("No reachable spawn points are available for the item spawner");

            PatrolPoint candidatePoint = null;

            //Attempt 10 times before giving up
            for (int i = 0; i < 10; i++)
            {
                candidatePoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

                if (FindObjectsOfType<ItemPickup>().Any(o => Vector3.Distance(candidatePoint.transform.position, o.transform.position) < 1f))
                    continue;

                if (Random.value > candidatePoint.ChanceToSelect)
                    continue;

                break;
            }

            if (candidatePoint != null)
            {
                Instantiate(
                    original: candidateItem,
                    position: candidatePoint.transform.position + Vector3.up * YOffset,
                    rotation: Quaternion.identity
                );
            }
        }
    }
}
