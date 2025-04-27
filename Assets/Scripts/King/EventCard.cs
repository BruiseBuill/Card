using Card;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace King
{
	public class EventCard : BaseCard
	{
        EventCardData data;
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] TextMeshProUGUI introductionText;

        public override void SetData(object data)
        {
            this.data = data as EventCardData;
        }

        [ContextMenu("Load")]
        public override void Load()
        {
            nameText.text = this.data.name;
            introductionText.text = this.data.introduction;
        }       
    }
}