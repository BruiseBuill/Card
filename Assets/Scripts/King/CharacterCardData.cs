using Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace King
{
    [CreateAssetMenu(fileName = "CharacterCardData", menuName = "King/CharacterCardData")]
    class CharacterCardData:ScriptableObject
    {
        public List<int> characterCountList;
    }
}
