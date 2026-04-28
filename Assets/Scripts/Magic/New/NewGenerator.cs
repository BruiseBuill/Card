using BF;
using Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting
{
    public class NewGenerator : BaseGenerator
    {
        [SerializeField] List<NormalCardData> dataList;
        [SerializeField] bool isLoading;
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
            var cardGo = Instantiate(testPrefab, Vector3.zero, Quaternion.identity);
            var card = cardGo.GetComponent<NormalCard>();
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
            isLoading = true;
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
            isLoading = false;  
        }
    }
}