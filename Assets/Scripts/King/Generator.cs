using Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace King
{
	public class Generator : BaseGenerator
	{
		[SerializeField] List<EventCardData> eventDataList;
        [SerializeField] CharacterCardData characterData;
        [SerializeField] bool isLoadingCharacter;
        [SerializeField] int index;
        [SerializeField] int subIndex;
        [SerializeField] int posIndex;

        [Header("Prefab")]
        [SerializeField] List<GameObject> characterPrefabList;
        [SerializeField] GameObject eventCardPrefab;


        protected override void Awake()
        {
            base.Awake();
            wait_Interval= new WaitForSeconds(interval);
        }
        void LoadEventCard(int index)
        {
            GameObject cardGo = Instantiate(eventCardPrefab, GetPos(posIndex), Quaternion.identity);
            cardGo.GetComponent<EventCard>().SetData(eventDataList[index]);
            cardGo.GetComponent<EventCard>().Load();
            cardGoList.Add(cardGo);
        }
        protected override IEnumerator Shotting()
        {
            isLoadingCharacter = true;
            index = 0;
            subIndex = 0;
            posIndex = 0;
            while (true)
            {
                if (index == eventDataList.Count && !isLoadingCharacter)
                {
                    break;
                }
                posIndex = 0;
                while (cardGoList.Count > 0)
                {
                    Destroy(cardGoList[0]);
                    cardGoList.RemoveAt(0);
                }
                LoadOnePage(index);
                screenShot.Capture();
                yield return wait_Interval;
            }
        }
        protected override void LoadOnePage(int noUse)
        {
            if (isLoadingCharacter)
            {
                while (index < characterData.characterCountList.Count && posIndex < size.x * size.y)
                {
                    testPrefab = characterPrefabList[index];
                    testIndex = posIndex;
                    TestLoad();
                    subIndex++;
                    posIndex++;
                    if (subIndex == characterData.characterCountList[index])
                    {
                        subIndex = 0;
                        index++;
                        if (index == characterData.characterCountList.Count)
                        {
                            index = 0;
                            isLoadingCharacter = false;
                        }
                        LoadOnePage(index);
                    }                    
                }
            }
            else
            {
                while (index < eventDataList.Count && posIndex < size.x * size.y)
                {
                    if (subIndex < eventDataList[index].count)
                    {
                        LoadEventCard(index);
                        subIndex++;
                        posIndex++;
                    }
                    else
                    {
                        subIndex = 0;
                        index++;
                    }
                }
            }
        }
        
    }
}