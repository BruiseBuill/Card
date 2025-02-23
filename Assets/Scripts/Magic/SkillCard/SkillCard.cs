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
        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI kindText;

        public void SetData(SkillCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        void Load()
        {

        }
    }
}
