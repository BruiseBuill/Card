using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    public enum MagicCardKind { Modify, Water, Flare, Grass, Universe, MagicPower, Special,All };

    [CreateAssetMenu(fileName = "SkillCardData", menuName = "Magic/SkillCardData")]
 	public class SkillCardData : ScriptableObject
	{
        new public string name;
        //Water,Flare,Grass,Universe,MagicPower,Special
        public MagicCardKind kind;
        public int level;
        public string mainDescription;
        public string additionalDescription;

        public Color color;
        static string colorTxt="";
        public string Prefix
        {
            get
            {
                if (colorTxt.Length == 0)
                {
                    int r = Mathf.Clamp(Mathf.RoundToInt(color.r * 255), 0, 255);
                    int g = Mathf.Clamp(Mathf.RoundToInt(color.g * 255), 0, 255);
                    int b = Mathf.Clamp(Mathf.RoundToInt(color.b * 255), 0, 255);
                    int a = Mathf.Clamp(Mathf.RoundToInt(color.a * 255), 0, 255);
                    colorTxt = $"#{r:X2}{g:X2}{b:X2}{a:X2}";
                }
                return colorTxt ;
            }
        }
    }
}
