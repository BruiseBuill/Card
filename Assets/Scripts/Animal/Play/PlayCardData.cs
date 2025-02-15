using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalParty
{
    public enum PlayCardType { Red,Green,Blue}
    [CreateAssetMenu(fileName = "CardData", menuName = "Animal/PlayCard")]
    public class PlayCardData : ScriptableObject
	{
        new public string name;

        public PlayCardType cardType;
        
        public string[] characterNameList;

        public string additionalTip;

        public string supContent;

        public int count;
    }
}
