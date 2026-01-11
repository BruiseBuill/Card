using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagicFighting2
{
	public class BigMagicCard : MagicCard
    {
        public Image profile;
        public Image supMaskProfile;

        [ContextMenu("Load2")]
        public override void Load()
        {
            base.Load();
            profile.sprite = Generator.Instance().GetProfile(cardData.name);
            supMaskProfile.sprite = profile.sprite;
        }
    }
}