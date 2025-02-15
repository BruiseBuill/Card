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
        public TextMeshProUGUI descriptionText;
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
