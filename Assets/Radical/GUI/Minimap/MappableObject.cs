using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.GUI.Minimap
{
    public class MappableObject : MonoBehaviour
    {
        public GameObject MapMarkerPrefab;

        private MinimapMaster _minimap;
        private GameObject _mapMarkerInWorld;

        private void Start()
        {
            _minimap = FindObjectOfType<MinimapMaster>();
            _mapMarkerInWorld = Instantiate(MapMarkerPrefab, _minimap.transform);
        }

        private void Update()
        {
            _mapMarkerInWorld.transform.localPosition = _minimap.WorldToMinimapPoint(transform.position);
        }

        private void OnDestroy()
        {
            if (_mapMarkerInWorld != null)
                Destroy(_mapMarkerInWorld);
        }
    }
}
