using BF;
using Card;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MagicFighting
{
 	public class Generator : Single<Generator>
	{
        [SerializeField] List<MagicCardData> magicCardDataList;
        [SerializeField] List<SkillCardData> skillCardDataList;
        [SerializeField] GameObject magicCardPrefab;
        [SerializeField] GameObject skillCardPrefab;

        [Header("Shot")]
        ScreenShot screenShot;
        [SerializeField] float interval;
        WaitForSeconds wait_Interval;

        [Header("Alignment")]
        [SerializeField] Vector3 offset;
        [SerializeField] protected int index;
        [SerializeField] protected int subIndex;
        [SerializeField] protected int posIndex;
        [SerializeField] bool isLoadingSkillCard;
        List<Vector3> cardPosList = new List<Vector3>();

        [Header("Test")]
        [SerializeField] Vector3 testCardPos;
        [SerializeField] MagicCardData testMagicCardData;
        [SerializeField] SkillCardData testSkillCardData;

        List<GameObject> cardGoList = new List<GameObject>();

        private void Awake()
        {
            wait_Interval = new WaitForSeconds(interval);
            screenShot = FindObjectOfType<ScreenShot>();
            cardPosList = new List<Vector3>()
            {
                new Vector3(-offset.x,offset.y),new Vector3(0,offset.y),offset,
                new Vector3(-offset.x,0),Vector3.zero, new Vector3(offset.x,0),
                -offset,new Vector3(0,-offset.y),new Vector3(offset.x,-offset.y)
            };
        }
        #region Load
        [ContextMenu("TestLoadMagicCard")]
        protected void TestLoadMagic()
        {
            LoadMagicCard(testCardPos, testMagicCardData);
        }
        [ContextMenu("TestLoadSkillCard")]
        protected void TestLoadSkill()
        {
            LoadSkillCard(testCardPos, testSkillCardData);
        }
        public void LoadMagicCard(Vector3 cardPos, MagicCardData cardData)
        {
            GameObject cardGo = Instantiate(magicCardPrefab, testCardPos, Quaternion.identity);
            cardGo.transform.position = cardPos;
            cardGo.GetComponent<MagicCard>().SetData(cardData);
            cardGo.GetComponent<MagicCard>().Load();
            cardGoList.Add(cardGo);
        }
        public void LoadSkillCard(Vector3 cardPos, SkillCardData cardData)
        {
            GameObject cardGo = Instantiate(skillCardPrefab, testCardPos, Quaternion.identity);
            cardGo.transform.position = cardPos;
            cardGo.GetComponent<SkillCard>().SetData(cardData);
            cardGo.GetComponent<SkillCard>().Load();
            cardGoList.Add(cardGo);
        }
        #endregion  
        
        void LoadNine()
        {
            if (isLoadingSkillCard)
            {
                while (index < skillCardDataList.Count && posIndex < cardPosList.Count)
                {
                    LoadSkillCard(cardPosList[posIndex], skillCardDataList[index]);
                    index++;
                    posIndex++;
                    if (index == skillCardDataList.Count)
                    {
                        isLoadingSkillCard = false;
                        index = 0;
                        LoadNine();
                    }
                }
            }
            else
            {
                while (index < magicCardDataList.Count && posIndex < cardPosList.Count)
                {
                    if (subIndex < magicCardDataList[index].count)
                    {
                        LoadMagicCard(cardPosList[posIndex], magicCardDataList[index]);
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
            isLoadingSkillCard = true;
            index = 0;
            subIndex = 0;
            posIndex = 0;
            StartCoroutine("Shotting");
        }
        IEnumerator Shotting()
        {
            while (true)
            {
                if (index == magicCardDataList.Count && !isLoadingSkillCard)
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
