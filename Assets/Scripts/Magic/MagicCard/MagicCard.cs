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
        public TextMeshProUGUI magicCostText_1;
        public TextMeshProUGUI descriptionText_1;

        public GameObject introductionForMPGo;
        public TextMeshProUGUI mpCardDescription;        

        public TextMeshProUGUI kindText;

        public void SetData(MagicCardData cardData)
        {
            this.cardData = cardData;
        }
        [ContextMenu("Load")]
        void Load()
        {

        }
    }
}
