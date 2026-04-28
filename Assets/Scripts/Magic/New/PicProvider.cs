using BF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
	public class PicProvider : Single<PicProvider>
	{
        [SerializeField] List<Sprite> cardTexture;
        [SerializeField] List<Sprite> cardKindBGTexture;
        [SerializeField] List<Sprite> normalCardKindTexture;

        public Sprite GetCardTexture(Rare rare) => cardTexture[(int)rare];
        public Sprite GetCardKindBGTexture(Rare rare) => cardKindBGTexture[(int)rare];
        public Sprite GetPropertyTexture(NormalCardProperty normalCardKind) => normalCardKindTexture[(int)normalCardKind];


    }
}