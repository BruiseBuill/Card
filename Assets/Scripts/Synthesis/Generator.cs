using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Synthesis
{
	public class Generator : MonoBehaviour
	{
		[SerializeField] List<Sprite> spriteList;
		Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();

		[SerializeField] List<GameObject> prefabList;


		public Sprite GetSprite(string name)
		{
			if (spriteDict.ContainsKey(name))
			{
				return spriteDict[name];
            }

			for (int i = 0; i < spriteList.Count; i++)
			{
				if (spriteList[i].name == name)
				{
					spriteDict.Add(name, spriteList[i]);
					
				}
            }
            return spriteDict[name];
        }

		
    }
}