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
    public class CheerText : MonoBehaviour
    {
        private TMP_Text _text;

        [Header("Smack!!")]
        public float SmackSpeed;
        public Vector3 SmackMaxSize;
        public float SustainLength;
        public AnimationCurve SmackCurve;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _text.enabled = false;
        }

        public void Smack(string text)
        {
            _text.text = text;
            
            StartCoroutine(smack());

            IEnumerator smack()
            {
                _text.enabled = true;

                Vector3 originalSize = transform.localScale;

                float lerpTime = 0f;
                while (lerpTime < 1f)
                {
                    transform.localScale = Vector3.Lerp(originalSize, SmackMaxSize, SmackCurve.Evaluate(lerpTime));

                    lerpTime += SmackSpeed;
                    yield return new WaitForEndOfFrame();
                }

                yield return new WaitForSeconds(SustainLength);

                _text.enabled = false;
            }
        }
    }
}
