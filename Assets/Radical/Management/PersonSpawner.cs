using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Person.Nav;
using UnityEngine;

namespace Assets.Radical.Management
{
    public class PersonSpawner : MonoBehaviour
    {
        private PatrolPoint[] _spawnPoints;
        public int SpawnCount { get; private set; }

        [Header("Init")]
        public int InitalSpawnAmount;

        [Header("Config")]
        public SpawnGroup[] Groups = new SpawnGroup[0];
        public float SpawnRadius = 1f;

        private void Awake()
        {
            _spawnPoints = FindObjectsOfType<PatrolPoint>();
        }

        private void Start()
        {
            for (int i = 0; i < InitalSpawnAmount; i++)
            {
                SpawnNew();
                SpawnCount = 0;
            }
        }

        public void SpawnNew()
        {
            SpawnCount++;

            GameObject prefab = Groups
                .OrderByDescending(i => i.Threshold)
                .FirstOrDefault(i => SpawnCount > i.Threshold).Prefab;

            if (prefab == null)
                throw new System.InvalidOperationException("No applicable spawn group was found for the person spawner");

            if (_spawnPoints.Length == 0 || _spawnPoints.Sum(i => i.ChanceToSelect) <= 0)
                throw new System.InvalidOperationException("No reachable spawn points are available for the person spawner");


            PatrolPoint candidate;
            do
            {
                candidate = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)];
            } while (Random.value > candidate.ChanceToSelect);

            Instantiate(
                original: prefab,
                position: candidate.transform.position + new Vector3(Random.Range(-SpawnRadius, SpawnRadius), 0f, Random.Range(-SpawnRadius, SpawnRadius)),
                rotation: Quaternion.identity
            );

        }
    }
}
