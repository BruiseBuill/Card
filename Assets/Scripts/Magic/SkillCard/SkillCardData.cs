using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    [CreateAssetMenu(fileName = "SkillCardData", menuName = "Magic/MagicCardData")]
 	public class SkillCardData : ScriptableObject
	{
        new public string name;
        //Flare,Water,Grass,Universe,MagicPower
        public string kind;
        public string description;
    }
}
