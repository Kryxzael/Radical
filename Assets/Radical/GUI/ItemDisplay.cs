using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Radical.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Radical.GUI
{
    [RequireComponent(typeof(Image))]
    public class ItemDisplay : MonoBehaviour
    {
        private Image _image;

        public ItemHolder Source;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            if (Source == null)
            {
                Debug.LogWarning("No source selected for item display");
                enabled = false;
            }

            _image.enabled = Source.HeldItem != null;
            _image.sprite = Source.HeldItem?.UISprite;
        }
    }
}
