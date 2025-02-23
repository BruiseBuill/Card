using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalParty
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Animal/CharacterCard")]
    public class CharacterCardData : ScriptableObject
	{
        new public string name;
        public List<string> foodName;
	}
}
