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
        [SerializeField] GameObject magicCardBackPrefab;
        [SerializeField] GameObject skillCardBackPrefab;
        [SerializeField] GameObject deathConsciencePrefab;
        [SerializeField] GameObject deathConscienceBackPrefab;
        [SerializeField] GameObject magicBarPrefab;

        [Header("Shot")]
        ScreenShot screenShot;
        [SerializeField] float interval;
        WaitForSeconds wait_Interval;

        [Header("Alignment")]
        static Vector3 offset = new Vector3(6.3f, 8.8f, 0);
        [SerializeField] protected int index;
        [SerializeField] protected int subIndex;
        [SerializeField] protected int posIndex;
        [SerializeField] bool isLoadingSkillCard;
        static List<Vector3> cardPosList = new List<Vector3>() { new Vector3(-offset.x,offset.y),new Vector3(0,offset.y),offset,
                new Vector3(-offset.x,0),Vector3.zero, new Vector3(offset.x,0),
                -offset,new Vector3(0,-offset.y),new Vector3(offset.x,-offset.y)};

        [Header("Test")]
        [SerializeField] int testIndex;
        int TestIndex
        {
            get 
            {
                var a = testIndex;
                if (cardPosList.Count != 0)
                {
                    testIndex = (testIndex + 1) % cardPosList.Count;
                }                
                return a;
            }
        }
        [SerializeField] MagicCardData testMagicCardData;
        [SerializeField] SkillCardData testSkillCardData;
        

        List<GameObject> cardGoList = new List<GameObject>();

        private void Awake()
        {
            wait_Interval = new WaitForSeconds(interval);
            screenShot = FindObjectOfType<ScreenShot>();
        }
        #region Load
        [ContextMenu("TestLoadMagicCard")]
        protected void TestLoadMagic()
        {
            LoadMagicCard(cardPosList[TestIndex], testMagicCardData);
            
        }
        [ContextMenu("TestLoadSkillCard")]
        protected void TestLoadSkill()
        {
            LoadSkillCard(cardPosList[TestIndex], testSkillCardData);
        }
        public void LoadMagicCard(Vector3 cardPos, MagicCardData cardData)
        {
            GameObject cardGo = Instantiate(magicCardPrefab, cardPos, Quaternion.identity);
            cardGo.transform.position = cardPos;
            cardGo.GetComponent<MagicCard>().SetData(cardData);
            cardGo.GetComponent<MagicCard>().Load();
            cardGoList.Add(cardGo);
        }
        public void LoadSkillCard(Vector3 cardPos, SkillCardData cardData)
        {
            GameObject cardGo = Instantiate(skillCardPrefab, cardPos, Quaternion.identity);
            cardGo.transform.position = cardPos;
            cardGo.GetComponent<SkillCard>().SetData(cardData);
            cardGo.GetComponent<SkillCard>().Load();
            cardGoList.Add(cardGo);
        }
        [ContextMenu("TestLoadMagicCardBack")]
        protected void TestLoadMagicCardBack()
        {
            Instantiate(magicCardBackPrefab, cardPosList[TestIndex], Quaternion.identity);
        }
        [ContextMenu("TestLoadSkillCardBack")]
        protected void TestLoadSkillCardBack()
        {
            Instantiate(skillCardBackPrefab, cardPosList[TestIndex], Quaternion.identity);
        }
        [ContextMenu("TestLoadDeathConscience")]
        protected void TestLoadDeathConscience()
        {
            Instantiate(deathConsciencePrefab, cardPosList[TestIndex], Quaternion.identity);
        }
        [ContextMenu("TestLoadDeathConscienceBack")]
        protected void TestLoadDeathConscienceBack()
        {
            Instantiate(deathConscienceBackPrefab, cardPosList[TestIndex], Quaternion.identity);
        }
        [ContextMenu("TestLoadMagicBar")]
        protected void TestLoadMagicBar()
        {
            Instantiate(magicBarPrefab, cardPosList[TestIndex], Quaternion.identity);
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
        [ContextMenu("ShotAll")]
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
