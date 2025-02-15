using BF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
 	public class SpriteManager : Single<SpriteManager>
	{
        [Header("elementImage")]
        [SerializeField] List<string> kindList;
        [SerializeField] List<Sprite> kindSpriteList;
        Dictionary<string, Sprite> kindDic = new Dictionary<string, Sprite>();

        [Header("MagicCardProfile")]
        [SerializeField] List<string> magicCardNameList;
        [SerializeField] List<Sprite> magicCardProfileList;
        Dictionary<string, Sprite> magicCardProfileDic = new Dictionary<string, Sprite>();

        private void Awake()
        {
            for(int i = 0; i < kindList.Count; i++)
            {
                kindDic.Add(kindList[i], kindSpriteList[i]);
            }
            for(int i = 0; i < magicCardNameList.Count; i++)
            {
                magicCardProfileDic.Add(magicCardNameList[i], magicCardProfileList[i]);
            }
        }
        public Sprite GetKindSprite(string name)
        {
            return kindDic[name];
        }
        public Sprite GetMagicCardProfile(string name)
        {
            return magicCardProfileDic[name];
        }
	}
}
