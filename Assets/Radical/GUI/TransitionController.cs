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
    public class TransitionController : MonoBehaviour
    {
        public string[] SplashTexts;

        public AnimationCurve DropClip;

        public float FallLength = 30;
        public float FallSpeed;
        public float SustainLength;

        public TMP_Text SplashTextLabel;

        private IEnumerator Start()
        {
            //Set splash
            string chosenSplash;

            if (SplashTexts.Length == 0)
                chosenSplash = "Error";

            else
                chosenSplash = SplashTexts[UnityEngine.Random.Range(0, SplashTexts.Length)];

            SplashTextLabel.text = chosenSplash;

            //Fall in
            {
                yield return OnBegin();

                Vector3 targetPosition = transform.position;
                transform.position += Vector3.up * FallLength;

                Vector3 originalPosition = transform.position;

                float lerpTime = 0f;
                while (lerpTime < 1f)
                {
                    transform.position = Vector3.Lerp(originalPosition, targetPosition, DropClip.Evaluate(lerpTime));

                    yield return new WaitForEndOfFrame();
                    lerpTime += FallSpeed;
                }

                transform.position = targetPosition;
            }

            //Wait
            yield return OnSustainStart();
            yield return new WaitForSecondsRealtime(SustainLength);
            yield return OnSustainEnd();

            //Fall out
            {
                Vector3 targetPosition = transform.position + Vector3.down * FallLength;
                Vector3 originalPosition = transform.position;

                float lerpTime = 0f;
                while (lerpTime < 1f)
                {
                    transform.position = Vector3.Lerp(originalPosition, targetPosition, lerpTime);

                    yield return new WaitForEndOfFrame();
                    lerpTime += FallSpeed;
                }

                yield return OnEnd();
            }
        }

        protected virtual IEnumerator OnBegin()
        {
            yield break;
        }

        protected virtual IEnumerator OnSustainStart()
        {
            yield break;
        }

        protected virtual IEnumerator OnSustainEnd()
        {
            yield break;
        }

        protected virtual IEnumerator OnEnd()
        {
            yield break;
        }

    }
}
