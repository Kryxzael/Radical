using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Radical.GUI
{
    public class SceneTransitionController : TransitionController
    {
        public string TargetScene;

        protected override IEnumerator OnSustainEnd()
        {
            DontDestroyOnLoad(transform.root);

            SceneManager.LoadScene(TargetScene);

            yield break;
        }
    }
}
