using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    [CreateAssetMenu(fileName = "MagicCardData",menuName = "Magic/MagicCardData")]
 	public class MagicCardData : ScriptableObject
	{
        new public string name;
        
        public MagicCardKind kind;

        public int count;

        public string effect_0_MagicCost;
        public string effect_1_MagicCost;
        public string effect_0_Description;
        public string effect_1_Description;

        
    }
}
