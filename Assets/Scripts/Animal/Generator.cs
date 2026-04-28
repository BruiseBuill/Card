using BF;
using Card;
using Summon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalParty
{
    public class Generator : BaseGenerator
	{
        [SerializeField] List<CharacterCardData> characterDataList;
        [SerializeField] List<PlayCardData> playDataList;
        [SerializeField] List<HumanCardData> humanDataList;
        [SerializeField] GameObject characterCardPrefab;
        [SerializeField] GameObject[] playCardPrefab;
        [SerializeField] GameObject humanCardPrefab;

        [Header("Alignment")]
        [SerializeField] protected int index;
        [SerializeField] protected int subIndex;
        [SerializeField] protected int posIndex;
        [SerializeField] bool isLoadingCharacter;

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

        protected override IEnumerator Shotting()
        {
            isLoadingCharacter = true;
            index = 0;
            subIndex = 0;
            posIndex = 0;
            while (index < playDataList.Count) 
            {
                yield return wait_Interval;
                posIndex = 0;
                while (cardGoList.Count > 0)
                {
                    Destroy(cardGoList[0]);
                    cardGoList.RemoveAt(0);
                }
                LoadOnePage(index);
                screenShot.Capture();
            }
        }
        protected override void LoadOnePage(int enoUse)
        {
            if (isLoadingCharacter)
            {
                for (int i = index; index < characterDataList.Count && posIndex < size.x * size.y; i++)
                {
                    LoadCharacter(GetPos(posIndex), characterDataList[index]);
                    index++;
                    posIndex++;
                    if (index == characterDataList.Count)
                    {
                        index = 0;
                        isLoadingCharacter = false;
                        LoadOnePage(index);
                    }
                }
            }
            else
            {
                for (int i = index; index < playDataList.Count && posIndex < size.x * size.y; i++)
                {
                    if (subIndex < playDataList[index].count)
                    {
                        LoadPlay(GetPos(posIndex), playDataList[index]);
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
        public Color GetHumanColor(string name)
        {
            return humanColorDic[name];
        }

        protected override GameObject LoadOneCard()
        {
            throw new System.NotImplementedException();
        }
    }
}
