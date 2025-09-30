using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Summon
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Self/SummonData")]
    public class CardData : ScriptableObject
    {
        public string index;
        new public string name;
        public string attack;
        public string defense;
        public string introduction;
        public string valueEffect;
        public Sprite profile;
    }
}
