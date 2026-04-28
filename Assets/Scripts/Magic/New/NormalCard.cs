using MagicFighting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagicFighting
{
	public class NormalCard : MonoBehaviour
	{
        [SerializeField] NormalCardData cardData;

        public Image cardTextureImage;

        [Header("Aside")]
        public Image propertyImage;
        public Image skillKindImage;
        public List<GameObject> timingIndices;

        [Header("Up")]
        public TextMeshProUGUI nameText;
        
        public Image profileImage;
        public Image kindTextBG;
        public TextMeshProUGUI kindText;

        [Header("Down")]
        public GameObject EffectForMagic;
        public GameObject EffectForNonMagic;

        public TextMeshProUGUI magicCostText;
        public TextMeshProUGUI descriptionTextForMagic;
        public TextMeshProUGUI descriptionTextForNonMagic;


        public void SetData(NormalCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        public void Load()
        {
            
            cardTextureImage.sprite = PicProvider.Instance().GetCardTexture(cardData.rare);
            if (!cardData.isSkill)
            {
                propertyImage.sprite = PicProvider.Instance().GetPropertyTexture(cardData.Property);
                skillKindImage.gameObject.SetActive(false);
            }
            else
            {
                propertyImage.sprite = PicProvider.Instance().GetPropertyTexture(NormalCardProperty.Book);
                skillKindImage.gameObject.SetActive(true);
                skillKindImage.sprite = PicProvider.Instance().GetPropertyTexture(cardData.Property);
            }

            timingIndices[0].SetActive(false);
            timingIndices[1].SetActive(false);
            if (cardData.timingForPutting % 2 == 1)
            {
                timingIndices[1].SetActive(true);
            }
            if (cardData.timingForPutting / 2 == 1)
            {
                timingIndices[0].SetActive(true);
            }

            nameText.text = cardData.name;
            profileImage.sprite= PicProvider.Instance().GetPropertyTexture(cardData.Property);
            kindTextBG.sprite = PicProvider.Instance().GetCardKindBGTexture(cardData.rare);
            kindText.text = cardData.kindDescription;

            if (cardData.isMagic)
            {
                EffectForMagic.SetActive(true);
                EffectForNonMagic.SetActive(false);
                magicCostText.text = cardData.effectCost.ToString();
                descriptionTextForMagic.text = cardData.effectDescription;
                descriptionTextForNonMagic.text = "";
            }
            else
            {
                EffectForMagic.SetActive(false);
                EffectForNonMagic.SetActive(true);
                magicCostText.text = "";
                descriptionTextForMagic.text = "";
                descriptionTextForNonMagic.text = cardData.effectDescription;
            }

        }
    }
}