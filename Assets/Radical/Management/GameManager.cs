using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.GUI;
using TMPro;
using UnityEngine;

namespace Assets.Radical.Management
{
    public class GameManager : MonoBehaviour
    {
        public bool IsGameRunning = true;

        [Header("Audio")]
        public AudioSource MusicSource;
        public AudioSource HitSource;

        [Header("Score")]
        public int Score;
        public TMP_Text ScoreToastPrefab;

        [Header("Cheer")]
        public CheerText[] CheerLabels;
        public int CheerScoreInterval = 1000;
        public string[] Cheers;

        [Header("Lifetime")]
        public GameObject GameOverOverlayPrefab;


        /// <summary>
        /// Adds some points to the total score and shows a toast where the points were earned
        /// </summary>
        /// <param name="points"></param>
        /// <param name="position"></param>
        public void ProvidePoints(int points, Vector3 position)
        {
            int previousScore = Score;
            Score += points;

            //Cheer
            if ((Score / CheerScoreInterval) > (previousScore / CheerScoreInterval) && Cheers.Length != 0 && Cheers.Length != 0)
            {
                CheerText candidate = CheerLabels[UnityEngine.Random.Range(0, CheerLabels.Length)];
                candidate.Smack(Cheers[UnityEngine.Random.Range(0, Cheers.Length)]);
                HitSource.Play();
            }

            TMP_Text toast = Instantiate(ScoreToastPrefab, position, Quaternion.identity);
            toast.text = points.ToString();
        }

        public void GameOver()
        {
            if (!IsGameRunning)
                return;

            MusicSource.Stop();

            IsGameRunning = false;
            GameObject gameOverScreen = Instantiate(GameOverOverlayPrefab, Vector2.zero, Quaternion.identity);
            gameOverScreen.transform.localPosition = new Vector3();

            ResultsConduit.PreviousState = new ResultsConduit(Score);
        }

    }
}
