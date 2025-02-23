using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnimalParty
{
 	public class CharacterCard : MonoBehaviour
	{
        [SerializeField] CharacterCardData cardData;

        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image profileImage;
        [SerializeField] Image[] foodImages;
        [SerializeField] TextMeshProUGUI[] foodNames;

        public void SetData(CharacterCardData cardData)
        {
            this.cardData = cardData;   
        }
        [ContextMenu("Load")]
        public void Load()
        {
            nameText.text = cardData.name;
            profileImage.sprite = SpriteManager.Instance().GetCharacterImage(cardData.name);

            for(int i = 0; i < foodImages.Length; i++)
            {
                foodNames[i].text = cardData.foodName[i];
                foodImages[i].sprite= SpriteManager.Instance().GetFoodImage(cardData.foodName[i]);
            }
        }
    }
}
