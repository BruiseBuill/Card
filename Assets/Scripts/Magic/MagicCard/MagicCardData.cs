using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    [CreateAssetMenu(fileName = "MagicCardData",menuName = "Magic/MagicCardData")]
 	public class MagicCardData : ScriptableObject
	{
        new public string name;
        //Flare,Water,Grass,Universe,MagicPower
        public string kind;
        public string description;
	}
}
