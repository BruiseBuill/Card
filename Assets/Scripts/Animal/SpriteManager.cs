using BF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalParty
{
    public class SpriteManager : Single<SpriteManager>
    {
        public static Dictionary<string, string> characterDic = new Dictionary<string, string>()
        {
            {"Ê¨×Ó","Lion"},
            {"ºï×Ó","Monkey" },
            {"ÐÜ" ,"Bear"},
            {"Â¹","Deer"},
            {"Ò°Öí" , "Pig" },
            {"ÎÚÑ»" , "Crow" },
            {"¶ì" , "Goose" },
            {"ðÃðÉ" , "Pelican" },
            {"Éß" , "Snake" },
            {"òáòæ" , "Lizard" },
        };
        public static Dictionary<string, string> foodDic = new Dictionary<string, string>()
        {
            {"ÊÞÈâ","Meat" },
            { "¸¯Èâ","RottenMeat"},
            { "ÄñÈâ","Bird"},
            { "²Ý","Grass"},
            { "Ê÷Ò¶","Leaf"},
            { "Ë®¹û","Fruit"},
            { "Óã","Fish"},
            { "À¥³æ","Insect"}
        };
        public static Dictionary<string, string> supDic = new Dictionary<string, string>()
        {
            { "ÒþÃØ¿úÊÓ","Peek" },
            { "ÒìÐÍÏû»¯","Digest"},
            { "²ÐÔü¼ø¶¨","Identify"},
            { "Ô¤²·ÏÈÖª","Predict"},
            { "Í»»÷¼ì²é","Inspect"},
            { "³ÁÄ¬ÊÇ½ð","Silence"},
            { "ÌØ±ð»íÃâ","Exempt"},
            { "Ç¿ÂòÇ¿Âô","Trade"}
        };
        [SerializeField] protected List<Sprite> characterSprites;
        protected Dictionary<string, Sprite> characterSpriteDic = new Dictionary<string, Sprite>();

        [SerializeField] protected List<Sprite> foodSprites;
        protected Dictionary<string, Sprite> foodSpriteDic = new Dictionary<string, Sprite>();

        [SerializeField] protected List<Sprite> supSprites;
        protected Dictionary<string,Sprite> supSpriteDic= new Dictionary<string, Sprite>();

        [SerializeField] Vector3[] characterProfileOffset;
        Dictionary<string, Vector3> characterOffsetDic = new Dictionary<string, Vector3>();

        private void Awake()
        {
            for (int i = 0; i < characterSprites.Count; i++)
            {
                characterSpriteDic.Add(characterSprites[i].name, characterSprites[i]);
            }
            for (int i = 0; i < foodSprites.Count; i++)
            {
                foodSpriteDic.Add(foodSprites[i].name, foodSprites[i]);
            }
            for(int i = 0; i < supSprites.Count; i++)
            {
                supSpriteDic.Add(supSprites[i].name, supSprites[i]);
            }
            for(int i = 0; i < characterProfileOffset.Length; i++)
            {
                characterOffsetDic.Add(characterSprites[i].name, characterProfileOffset[i]);
            }
        }
        public Sprite GetCharacterImage(string name)
        {
            return characterSpriteDic[characterDic[name]];
        }
        public Sprite GetFoodImage(string name)
        {
            return foodSpriteDic[foodDic[name]];
        }
        public Sprite GetSupImage(string name)
        {
            return supSpriteDic[supDic[name]];
        }
        public Vector3 GetOffset(string name)
        {
            return characterOffsetDic[characterDic[name]];
        }
    }
}
