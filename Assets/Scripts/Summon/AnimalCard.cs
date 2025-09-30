using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Summon
{
	public class AnimalCard : MonoBehaviour
	{
        [SerializeField] CardData cardData;

        public TextMeshProUGUI nameText;
        public TextMeshProUGUI attackText;
        public TextMeshProUGUI defenseText;
        public TextMeshProUGUI introductionText;
        public TextMeshProUGUI valueEffectText;
        public Image profilrImage;

        public void SetData(CardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        public void Load()
        {
            nameText.text = cardData.name;
            attackText.text = cardData.attack;
            defenseText.text = cardData.defense;
            introductionText.text = cardData.introduction;
            valueEffectText.text = cardData.valueEffect;
            profilrImage.sprite = cardData.profile;
        }
    }
}