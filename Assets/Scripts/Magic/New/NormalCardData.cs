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

        public string kindDescription;

		public bool isMagic;
		
		public Rare rare;

        public NormalCardProperty Property;
		public bool isSkill;

		public int timingForPutting;
        public string effectDescription;
        public string effectCost;
    }
	public enum Rare
	{
		Grey,
		Purple,
		Gold
	}
	public enum NormalCardProperty
	{
		PhysicsAttack,
		PhysicsDefense,
		Flare,
		Water,
		Grass,
		Mana,
		Special,
		Book
    }
}