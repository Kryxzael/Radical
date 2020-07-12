using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.General;
using UnityEngine;

namespace Assets.Radical.Player
{
    [RequireComponent(typeof(DirectionManager))]
    public class AirhornController : MonoBehaviour
    {
        public AudioSource AirhornSound;
        public GameObject ShockwavePrefab;
        public float YOffset;
        public bool UsingAirhorn { get; private set; }

        private DirectionManager _directionManager;


        private void Awake()
        {
            _directionManager = GetComponent<DirectionManager>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire"))
                UseAirhorn();
        }

        public void UseAirhorn()
        {
            UsingAirhorn = true;
            Instantiate(
                original: ShockwavePrefab, 
                position: transform.position + Vector3.up * YOffset, 
                rotation: Quaternion.Euler(new Vector3(0, GetLauchDirection(), 0))
            );
            AirhornSound.Play();

            Invoke(nameof(StopUsingAirhorn), 0.75f);
        }

        private void StopUsingAirhorn()
        {
            UsingAirhorn = false;
        }

        private float GetLauchDirection()
        {
            const float ANGLE_OFFSET = 0f;

            bool forward = _directionManager.FacingForwards;
            bool rightwards = _directionManager.FacingRightwards;

            if (forward)
            {
                if (rightwards)
                    return ANGLE_OFFSET + 90 + 45;

                return ANGLE_OFFSET - 90 - 45;
            }
            else
            {
                if (rightwards)
                    return ANGLE_OFFSET + 45;

                return ANGLE_OFFSET - 45;
            }
        }
    }
}
