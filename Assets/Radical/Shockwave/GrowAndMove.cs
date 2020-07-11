using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Shockwave
{
    public class GrowAndMove : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        public float Speed;
        public Vector3 MaxSize;
        public float MaxDistance;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public IEnumerator Start()
        {
            float lerpTime = 0f;
            Vector3 originalSize = transform.localScale; 
            Vector3 originalPosition = transform.position;

            while (lerpTime < 1f)
            {
                transform.position = Vector3.Lerp(originalPosition, originalPosition + transform.forward * MaxDistance, lerpTime);
                transform.localScale = Vector3.Lerp(originalSize, MaxSize, lerpTime);

                if (_renderer != null)
                    _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1f - lerpTime);

                lerpTime += Speed;
                yield return new WaitForEndOfFrame();
            }

            Destroy(gameObject);
        }
    }
}
