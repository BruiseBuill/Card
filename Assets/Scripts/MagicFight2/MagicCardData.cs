using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting2
{
    [CreateAssetMenu(fileName = "MagicCardData", menuName = "Magic2/MagicCardData")]
    public class MagicCardData : ScriptableObject
	{
        new public string name;
        public string cost;
        public string description;
    }
}