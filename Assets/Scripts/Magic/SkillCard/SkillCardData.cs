using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    public enum MagicCardKind { Water, Flare, Grass, Universe, MagicPower, Special, Modify};

    [CreateAssetMenu(fileName = "SkillCardData", menuName = "Magic/MagicCardData")]
 	public class SkillCardData : ScriptableObject
	{
        new public string name;
        //Water,Flare,Grass,Universe,MagicPower,Special
        public MagicCardKind kind;
        public string mainDescription;

        public string additionalDescription;
    }
}
