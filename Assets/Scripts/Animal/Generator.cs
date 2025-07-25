using BF;
using Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalParty
{
    [RequireComponent(typeof(ScreenShot))]
    public class Generator : BaseGenerator
	{
        [SerializeField] List<CharacterCardData> characterDataList;
        [SerializeField] List<PlayCardData> playDataList;
        [SerializeField] List<HumanCardData> humanDataList;
        [SerializeField] GameObject characterCardPrefab;
        [SerializeField] GameObject[] playCardPrefab;
        [SerializeField] GameObject humanCardPrefab;

        [Header("Alignment")]
        [SerializeField] Vector3 offset;
        [SerializeField] protected int index;
        [SerializeField] protected int subIndex;
        [SerializeField] protected int posIndex;
        [SerializeField] bool isLoadingCharacter;

        [Header("Shot")]
        [SerializeField] float interval;
        WaitForSeconds wait_Interval;

        Dictionary<string, Color> humanColorDic = new Dictionary<string, Color>();

        protected override void Awake()
        {
            base.Awake();
            wait_Interval = new WaitForSeconds(interval);
            for (int i = 0; i < humanDataList.Count; i++)
            {
                humanColorDic.Add(humanDataList[i].name, humanDataList[i].color);
            }
        }
        #region Load

        void LoadCharacter(Vector3 cardPos,CharacterCardData characterData)
        {
            var card = Instantiate(characterCardPrefab).GetComponent<CharacterCard>();
            card.transform.position = cardPos;
            card.SetData(characterData);
            card.Load();
            cardGoList.Add(card.gameObject);
        }
        void LoadPlay(Vector3 cardPos,PlayCardData playCardData)
        {
            var card = Instantiate(playCardPrefab[(int)playCardData.cardType]).GetComponent<PlayCard>();
            card.transform.position = cardPos;
            card.SetData(playCardData);
            card.Load();
            cardGoList.Add(card.gameObject);
        }
        void LoadHuman(Vector3 cardPos,HumanCardData humanCardData)
        {
            var card = Instantiate(humanCardPrefab).GetComponent<HumanCard>();
            card.transform.position = cardPos;
            card.SetData(humanCardData);
            card.Load();
            cardGoList.Add(card.gameObject);
        }
        #endregion

        [ContextMenu("TestLoad")]
        void TestLoadPage()
        {
            for(int i = 0; i < cardPosList.Count&& i <humanDataList.Count; i++)
            {
                var card = Instantiate(humanCardPrefab, cardPosList[i], Quaternion.identity);
                card.GetComponent<HumanCard>().SetData(humanDataList[i]);
                card.GetComponent<HumanCard>().Load();
            }
        }
        
        void LoadNine()
        {
            if (isLoadingCharacter)
            {
                while(index < characterDataList.Count && posIndex < cardPosList.Count)
                {
                    LoadCharacter(cardPosList[posIndex], characterDataList[index]);
                    index++;
                    posIndex++;
                    if (index == characterDataList.Count)
                    {
                        isLoadingCharacter = false;
                        index = 0;
                        LoadNine();
                    }
                }
            }
            else
            {
                while(index < playDataList.Count && posIndex < cardPosList.Count)
                {
                    if (subIndex < playDataList[index].count)
                    {
                        LoadPlay(cardPosList[posIndex], playDataList[index]);
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
        [ContextMenu("Shot")]
        public void Shot()
        {
            isLoadingCharacter = true;
            index = 0;
            subIndex = 0;
            posIndex = 0;
            StartCoroutine("Shotting");
        }
        IEnumerator Shotting()
        {
            while (index < playDataList.Count) 
            {
                yield return wait_Interval;
                posIndex = 0;
                while (cardGoList.Count > 0)
                {
                    Destroy(cardGoList[0]);
                    cardGoList.RemoveAt(0);
                }
                LoadNine();
                screenShot.Capture();
            }
        }
        public Color GetHumanColor(string name)
        {
            return humanColorDic[name];
        }
    }
}
