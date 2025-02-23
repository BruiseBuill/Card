using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    [CreateAssetMenu(fileName = "MagicCardData",menuName = "Magic/MagicCardData")]
 	public class MagicCardData : ScriptableObject
	{
        new public string name;
        //Water,Flare,Grass,Universe,MagicPower,Special
        public MagicCardKind kind;

        public int effect_0_MagicCost;
        public int effect_1_MagicCost;
        public string effect_0_Description;
        public string effect_1_Description;
    }
}
