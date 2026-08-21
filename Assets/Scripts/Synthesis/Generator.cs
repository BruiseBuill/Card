using Card;
using MagicFighting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Synthesis
{
	public class Generator : BaseGenerator
    {
		[SerializeField] List<Sprite> spriteList;
		Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();

		[SerializeField] List<GameObject> prefabList;

		[SerializeField] List<TreasureData> dataList;
        int index;
        int subIndex;

        protected override GameObject LoadOneCard()
        {
            if (index >= dataList.Count || subIndex >= dataList[index].count)
            {
                subIndex = 0;
                index++;
                if (index >= dataList.Count)
                {
                    return null;
                }
            }
            var cardGo = Instantiate(prefabList[dataList[index].colorIndex], Vector3.zero, Quaternion.identity);
            var card = cardGo.GetComponent<TreasureCard>();
            card.SetData(dataList[index]);
            card.Load();
            subIndex++;
            return cardGo;
        }
        protected override void LoadOnePage(int index)
        {
            throw new System.NotImplementedException();
        }
        protected override IEnumerator Shotting()
        {
            index = 0;
            subIndex = 0;
            while (index < dataList.Count)
            {
                yield return wait_Interval;
                while (cardGoList.Count > 0)
                {
                    Destroy(cardGoList[0]);
                    cardGoList.RemoveAt(0);
                }
                LoadOnePage();
                screenShot.Capture();
            }
        }
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