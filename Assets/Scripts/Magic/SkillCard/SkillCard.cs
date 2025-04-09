using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagicFighting
{
 	public class SkillCard : MonoBehaviour
	{
        [SerializeField] SkillCardData cardData;

        public TextMeshProUGUI nameText;
        public Image kindImage;
        public TextMeshProUGUI levelText;

        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI additionalDescriptionText;
        public TextMeshProUGUI kindText;

        static Dictionary<MagicCardKind,string> kindTextDic = new Dictionary<MagicCardKind, string>()
        {
            {MagicCardKind.Modify, "修饰性技能"},
            {MagicCardKind.Water, "水属性技能"},
            {MagicCardKind.Flare, "火属性技能"},
            {MagicCardKind.Grass, "草属性技能"},     
            {MagicCardKind.Universe, "万能属性技能"},
            {MagicCardKind.MagicPower, "法力技能"},
            {MagicCardKind.Special, "特殊技能"}
        };

        public void SetData(SkillCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        public void Load()
        {
            nameText.text = cardData.name;
            kindImage.sprite = SpriteManager.Instance().GetKindSprite(cardData.kind);
            levelText.text = cardData.level.ToString();
            descriptionText.text = "          "+cardData.mainDescription;
            additionalDescriptionText.text = cardData.additionalDescription;
            kindText.text = kindTextDic[cardData.kind];
        }
    }
}
