using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Radical.GUI
{
    [RequireComponent(typeof(TMP_Text))]
    public class RisingToast : MonoBehaviour
    {
        public float RiseHeight;
        public float Speed;

        private IEnumerator Start()
        {
            TMP_Text textComponent = GetComponent<TMP_Text>();

            Vector3 originalPosition = transform.position;

            float lerpTime = 0f;
            while (lerpTime < 1f)
            {
                transform.position = Vector3.Lerp(originalPosition, originalPosition + Vector3.up * RiseHeight, lerpTime);
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 1f - lerpTime);


                lerpTime += Speed;
                yield return new WaitForEndOfFrame();
            }

            Destroy(gameObject);
        }
    }
}
