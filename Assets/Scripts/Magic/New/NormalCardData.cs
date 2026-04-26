using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    [CreateAssetMenu(fileName = "NormalCardData", menuName = "Self/Magic/NormalCardData")]
    public class NormalCardData : ScriptableObject
	{
		new public string name;
		public int count;

		public NormalCardKind kind;
		public bool isSkill;

		public int timingForPutting;
        public string effectDescription;
        public string effectCost;
    }
	public enum NormalCardKind
	{
		PhysicsAttack,
		PhysicsDefense,
		Flare,
		Water,
		Grass,
		Mana,
		Special
    }
}