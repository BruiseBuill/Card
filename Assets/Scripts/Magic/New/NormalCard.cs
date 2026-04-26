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
        [SerializeField] MagicCardData cardData;

        public Image cardTextureImage;

        [Header("Aside")]
        public Image PropertyImage;
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



    }
}