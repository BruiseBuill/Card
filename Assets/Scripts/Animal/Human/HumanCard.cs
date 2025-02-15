using AnimalParty;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnimalParty
{
 	public class HumanCard : MonoBehaviour
	{
        [SerializeField] HumanCardData cardData;

        [SerializeField] SpriteRenderer spriteRender;
        [SerializeField] Image nameBgImage;

        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image profileImage;
        [SerializeField] TextMeshProUGUI backgroundText;
        [SerializeField] TextMeshProUGUI perspectiveText;
        [SerializeField] TextMeshProUGUI otherRelationText;
        [SerializeField] TextMeshProUGUI skillText;

        public void SetData(HumanCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        public void Load()
        {
            nameText.text = cardData.name;

            spriteRender.color = cardData.color;
            nameBgImage.color = cardData.color;

            profileImage.sprite = cardData.sprite;

            backgroundText.text = cardData.background;
            perspectiveText.text = cardData.perspetive;
            otherRelationText.text = cardData.otherRelation;
            skillText.text = cardData.skill;
        }


    }
}
