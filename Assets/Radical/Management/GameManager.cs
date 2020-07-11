using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Radical.Management
{
    public class GameManager : MonoBehaviour
    {
        public bool IsGameRunning = true;

        [Header("Score")]
        public int Score;
        public TMP_Text ScoreToastPrefab;

        [Header("Lifetime")]
        public GameObject GameOverOverlayPrefab;


        /// <summary>
        /// Adds some points to the total score and shows a toast where the points were earned
        /// </summary>
        /// <param name="points"></param>
        /// <param name="position"></param>
        public void ProvidePoints(int points, Vector3 position)
        {
            Score += points;

            TMP_Text toast = Instantiate(ScoreToastPrefab, position, Quaternion.identity);
            toast.text = points.ToString();
        }

        public void GameOver()
        {
            if (!IsGameRunning)
                return;

            IsGameRunning = false;
            GameObject gameOverScreen = Instantiate(GameOverOverlayPrefab, Vector2.zero, Quaternion.identity);
            gameOverScreen.transform.localPosition = new Vector3();

            ResultsConduit.PreviousState = new ResultsConduit(Score);
        }

    }
}
