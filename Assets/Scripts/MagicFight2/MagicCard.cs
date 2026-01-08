using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagicFighting2
{
	public class MagicCard : MonoBehaviour
	{
        [SerializeField] protected MagicCardData cardData;

        public TextMeshProUGUI nameText;
        public TextMeshProUGUI powerText;
        public TextMeshProUGUI coolDownText;
        public TextMeshProUGUI descriptionText;

        public void SetData(MagicCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        public virtual void Load()
        {
            nameText.text = cardData.name;
            powerText.text=cardData.power;
            coolDownText.text = cardData.coolDown;
            descriptionText.text = cardData.description;
        }
    }
}