using MagicFighting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagicFighting
{
 	public class MagicCard : MonoBehaviour
	{
        [SerializeField] MagicCardData cardData;

        public TextMeshProUGUI nameText;
        public Image kindImage;
        public Image profileImage;

        public GameObject introductionForNormalGo;
        public TextMeshProUGUI magicCostText_0;
        public TextMeshProUGUI descriptionText_0;
        public GameObject costObject_1;
        public TextMeshProUGUI magicCostText_1;
        public TextMeshProUGUI descriptionText_1;

        public GameObject introductionForMPGo;
        public TextMeshProUGUI mpCardDescription;        

        public TextMeshProUGUI kindText;

        static Dictionary<MagicCardKind,string> kindTextDic =new Dictionary<MagicCardKind, string>
        {
            {MagicCardKind.Water, "水属性法术"},
            {MagicCardKind.Flare, "火属性法术"},
            { MagicCardKind.Grass, "草属性法术"},     
            { MagicCardKind.Universe, "万能属性法术"},
            { MagicCardKind.MagicPower, "法力牌"},
            { MagicCardKind.Special, "特殊法术"}
        };
        public void SetData(MagicCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        public void Load()
        {
            nameText.text = cardData.name;
            kindImage.sprite = SpriteManager.Instance().GetKindSprite(cardData.kind);
            profileImage.sprite = SpriteManager.Instance().GetMagicCardProfile(cardData.name);
            kindText.text = kindTextDic[cardData.kind];
            if (cardData.kind == MagicCardKind.MagicPower)
            {
                introductionForNormalGo.SetActive(false);
                introductionForMPGo.SetActive(true);
                mpCardDescription.text = cardData.effect_0_Description;
            }
            else
            {
                introductionForNormalGo.SetActive(true);
                introductionForMPGo.SetActive(false);
                magicCostText_0.text = cardData.effect_0_MagicCost;
                descriptionText_0.text = cardData.effect_0_Description;
                if (cardData.effect_1_MagicCost != null)
                {
                    magicCostText_1.text = cardData.effect_1_MagicCost;
                    descriptionText_1.text = cardData.effect_1_Description;
                }
                else
                {
                    costObject_1.SetActive(false);
                }
            }

        }
    }
}
