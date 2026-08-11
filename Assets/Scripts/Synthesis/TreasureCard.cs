using Summon;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Synthesis
{
	public class TreasureCard : MonoBehaviour
	{
		[SerializeField] TreasureData treasureData;

        [SerializeField] TextMeshProUGUI nameText;
		[SerializeField] TextMeshProUGUI hardScoreText;
		[SerializeField] TextMeshProUGUI synthesisScoreText;
		[SerializeField] Image profileImage;
		[SerializeField] TextMeshProUGUI effectText;

        public void SetData(TreasureData cardData)
        {
            treasureData = cardData;
        }
        [ContextMenu("Load")]
        public virtual void Load()
        {
            nameText.text = treasureData.name;
            hardScoreText.text = treasureData.hardScore;
            synthesisScoreText.text = treasureData.synthesisScore;
            effectText.text = treasureData.effect;

        }

    }
}