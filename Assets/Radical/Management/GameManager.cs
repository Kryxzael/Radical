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
        [Header("Score")]
        public int Score;
        public TMP_Text ScoreToastPrefab;

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
    }
}
