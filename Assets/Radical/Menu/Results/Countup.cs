using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Management;
using TMPro;
using UnityEngine;

namespace Assets.Radical.Menu.Results
{
    [RequireComponent(typeof(TMP_Text))]
    public class Countup : MonoBehaviour
    {

        [Header("Countup")]
        public float CountupSpeed;
        public AnimationCurve CountupCurve;

        [Header("Smack!!")]
        public float SmackSpeed;
        public Vector3 SmackMaxSize;
        public AnimationCurve SmackCurve;


        private IEnumerator Start()
        {
            TMP_Text textComponent = GetComponent<TMP_Text>();

            //Countup
            {
                float lerpTime = 0f;
                while (lerpTime < 1f)
                {
                    textComponent.text = Mathf.Clamp((int)Math.Floor(CountupCurve.Evaluate(lerpTime) * ResultsConduit.PreviousState.Score), 0, ResultsConduit.PreviousState.Score).ToString("#,###,##0");

                    lerpTime += CountupSpeed;
                    yield return new WaitForEndOfFrame();
                }
            }

            //Smack
            {
                Vector3 originalSize = transform.localScale;

                float lerpTime = 0f;
                while (lerpTime < 1f)
                {
                    transform.localScale = Vector3.Lerp(originalSize, SmackMaxSize, SmackCurve.Evaluate(lerpTime));

                    lerpTime += SmackSpeed;
                    yield return new WaitForEndOfFrame();
                }
            }
        }
    }
}
