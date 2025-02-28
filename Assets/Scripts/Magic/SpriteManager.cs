using BF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
 	public class SpriteManager : Single<SpriteManager>
	{
        [Header("KindImage")]
        [SerializeField] List<Sprite> kindSpriteList;
        Dictionary<MagicCardKind, Sprite> kindDic = new Dictionary<MagicCardKind, Sprite>();

        [Header("MagicCardProfile")]
        [SerializeField] List<string> magicCardNameList;
        [SerializeField] List<Sprite> magicCardProfileList;
        Dictionary<string, Sprite> magicCardProfileDic = new Dictionary<string, Sprite>();

        private void Awake()
        {
            for(int i = 0; i < (int)MagicCardKind.All; i++)
            {
                kindDic.Add((MagicCardKind)i, kindSpriteList[i]);
            }
            for(int i = 0; i < magicCardNameList.Count; i++)
            {
                magicCardProfileDic.Add(magicCardNameList[i], magicCardProfileList[i]);
            }
        }
        public Sprite GetKindSprite(MagicCardKind name)
        {
            return kindDic[name];
        }
        public Sprite GetMagicCardProfile(string name)
        {
            return magicCardProfileDic[name];
        }
	}
}
