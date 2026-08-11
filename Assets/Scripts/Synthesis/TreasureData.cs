using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Synthesis
{
    [CreateAssetMenu(fileName = "TreasureData", menuName = "Self/Synthesis/TreasureData")]
    public class TreasureData : ScriptableObject
	{
		public new string name;
		public string hardScore;
		public string synthesisScore;
		public int colorIndex;
		public string effect;

		[Space]
		public int count;
    }
}