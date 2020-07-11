using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Radical.General
{
    [CreateAssetMenu(menuName = "Two Sided Animation", fileName = "New Two Sided Animation")]
    public class TwosidedSpriteAnimation : ScriptableObject
    {
        public SpriteAnimation Front;
        public SpriteAnimation Back;
    }
}
