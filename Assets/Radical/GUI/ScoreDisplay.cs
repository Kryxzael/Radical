using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Management;
using TMPro;
using UnityEngine;

namespace Assets.Radical.GUI
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreDisplay : MonoBehaviour
    {
        private TMP_Text _text;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = _gameManager.Score.ToString("0,000,000");
        }

    }
}
