using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnimalParty
{
 	public class PlayCard : MonoBehaviour
	{
        [SerializeField] PlayCardData cardData;

        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image profileImage;

        [Header("Food")]
        [SerializeField] Transform characterAreaBG;
        [SerializeField] GameObject characterPrefab;

        [Header("Sup")]
        [SerializeField] TextMeshProUGUI supContentText;

        public void SetData(PlayCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        public void Load()
        {
            nameText.text = cardData.name;
            if (cardData.cardType != PlayCardType.Blue)
            {
                profileImage.sprite = SpriteManager.Instance().GetFoodImage(cardData.name);
            }
            else
            {
                profileImage.sprite = SpriteManager.Instance().GetSupImage(cardData.name);
            }


            if (cardData.cardType != PlayCardType.Blue)
            {
                
                for (int i = 0; i < cardData.characterNameList.Length; i++)
                {
                    var go = Instantiate(characterPrefab);
                    go.transform.parent = characterAreaBG;
                    go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = cardData.characterNameList[i];
                    go.transform.Find("Profile").GetChild(0).GetComponent<Image>().sprite = SpriteManager.Instance().GetCharacterImage(cardData.characterNameList[i]);
                    go.transform.Find("Profile").GetChild(0).transform.localPosition = SpriteManager.Instance().GetOffset(cardData.characterNameList[i]);
                }
            }
            else
            {
                supContentText.text = cardData.supContent;
            }
            
        }
    }
}
