using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.Menu.Main
{
    public class MainMenuNavigation : MonoBehaviour
    {
        public GameObject LoadGameTransitionPrefab;

        public void OnClickStartGame()
        {
            Instantiate(LoadGameTransitionPrefab);
        }

        public void OnClickExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
