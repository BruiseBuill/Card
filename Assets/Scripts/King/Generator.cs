using Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace King
{
	public class Generator : BaseGenerator,IStandardGenerator
	{
		[SerializeField] List<EventCardData> eventDataList;
        [SerializeField] CharacterCardData characterData;
        [SerializeField] bool isLoadingCharacter;
        [SerializeField] int index;
        [SerializeField] int subIndex;
        [SerializeField] int posIndex;
        protected static float interval = 0.8f;
        WaitForSeconds wait_Interval;

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
            GameObject cardGo = Instantiate(eventCardPrefab, cardPosList[posIndex], Quaternion.identity);
            cardGo.GetComponent<EventCard>().SetData(eventDataList[index]);
            cardGo.GetComponent<EventCard>().Load();
            cardGoList.Add(cardGo);
        }
        public void LoadNine()
        {
            if (isLoadingCharacter)
            {
                while (index < characterData.characterCountList.Count && posIndex < cardPosList.Count)
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
                        LoadNine();
                    }                    
                }
            }
            else
            {
                while (index < eventDataList.Count && posIndex < cardPosList.Count)
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
        [ContextMenu("ShotAll")]
        public void ShotAll()
        {
            isLoadingCharacter = true;
            index = 0;
            subIndex = 0;
            posIndex = 0;
            StartCoroutine("Shotting");
        }
        IEnumerator Shotting()
        {
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
                LoadNine();
                screenShot.Capture();
                yield return wait_Interval;
            }
        }
    }
}