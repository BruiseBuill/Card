using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalParty
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Animal/HumanCard")]
    public class HumanCardData : ScriptableObject
	{
        new public string name;
        public Sprite sprite;
        public Color color;
        [TextArea(2,5)]
        public string background;
        [TextArea(2, 10)]
        public string perspetive;
        [TextArea(2, 10)]
        public string otherRelation;
        [TextArea(2,6)]
        public string skill;
        public string alphaInBG;

        [SerializeField]
        string colorTxt;
        public string Prefix
        {
            get
            {
                if (colorTxt.Length == 0)
                {
                    int r = Mathf.Clamp(Mathf.RoundToInt(color.r * 255), 0, 255);
                    int g = Mathf.Clamp(Mathf.RoundToInt(color.g * 255), 0, 255);
                    int b = Mathf.Clamp(Mathf.RoundToInt(color.b * 255), 0, 255);

                    colorTxt = $"{r:X2}{g:X2}{b:X2}";
                }
                return string.Format("<mark=#{0}{1}><color=#FFFFFFFF><b>", colorTxt, alphaInBG);
            }
        }
        public string Suffix
        {
            get
            {
                return string.Format("</mark></color></b>");
            }
        }

    }
}
