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
        [SerializeField] List<Sprite> magicCardProfileList;
        Dictionary<string, Sprite> magicCardProfileDic = new Dictionary<string, Sprite>();

        [SerializeField] Sprite defaultSprite;

        private void Awake()
        {
            for(int i = 0; i < (int)MagicCardKind.All; i++)
            {
                kindDic.Add((MagicCardKind)i, kindSpriteList[i]);
            }
            for(int i = 0; i < magicCardProfileList.Count; i++)
            {
                magicCardProfileDic.Add(magicCardProfileList[i].name, magicCardProfileList[i]);
            }
        }
        public Sprite GetKindSprite(MagicCardKind name)
        {
            if (kindDic.ContainsKey(name))
                return kindDic[name];
            else
                return defaultSprite;
        }
        public Sprite GetMagicCardProfile(string name)
        {
            if (magicCardProfileDic.ContainsKey(name))
                return magicCardProfileDic[name];
            else
                return defaultSprite;
        }
	}
}
