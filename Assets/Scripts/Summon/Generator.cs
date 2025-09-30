using BF;
using Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Summon
{
 	public class Generator : Single<Generator>
    {
        [SerializeField] List<CardData> dataList = new List<CardData>();

        [Header("Test")]
        [SerializeField] protected GameObject testPrefab;
        [SerializeField] protected int testIndex;
        protected int TestIndex
        {
            get
            {
                var a = testIndex;
                testIndex = (testIndex + 1) % (size.x * size.y);
                return a;
            }
        }

        protected ScreenShot screenShot;

        [Header("Alignment")]
        static Vector3 offset = new Vector3(4.95f, 6.9f, 0);
        static Vector2Int size = new Vector2Int(4, 4);

        [Header("Shot")]
        [SerializeField] float interval = 0.9f;
        WaitForSeconds wait_Interval;


        protected List<GameObject> cardGoList = new List<GameObject>();

        public List<Sprite> profileList = new List<Sprite>();
        protected Dictionary<string, Sprite> profileDic = new Dictionary<string, Sprite>();

       

        private void Awake()
        {
            wait_Interval = new WaitForSeconds(interval);
            screenShot = FindObjectOfType<ScreenShot>();
        }
        protected Vector3 GetPos(int index)
        {
            return new Vector3(-0.5f * size.x * offset.x + (index % size.x) * offset.x, 0.5f * size.y * offset.y - index / size.x * offset.y) + new Vector3(offset.x, -offset.y) * 0.5f;
        }

        [ContextMenu("Shot")]
        public void Shot()
        {
            StartCoroutine("Shotting");
        }
        IEnumerator Shotting()
        {
            int index = 0;
            while (index < dataList.Count)
            {
                yield return wait_Interval;

                while (cardGoList.Count > 0)
                {
                    Destroy(cardGoList[0]);
                    cardGoList.RemoveAt(0);
                }
                LoadOnePage(index);
                index += size.x * size.y;
                screenShot.Capture();
            }
        }
        void LoadOnePage(int index)
        {
            for (int i = index; i < dataList.Count && i < size.x * size.y + index; i++)
            {
                var cardGo = Instantiate(testPrefab, GetPos(i - index), Quaternion.identity);
                var card = cardGo.GetComponent<AnimalCard>();
                card.SetData(dataList[i]);
                card.Load();
                cardGoList.Add(cardGo);
            }
        }


        public Sprite GetProfile(string name)
        {
            if (profileDic == null || profileDic.Count == 0)
            {
                CreateDic();
            }
            if (profileDic.ContainsKey(name))
            {
                return profileDic[name];
            }
            else
            {
                foreach (var profile in profileList)
                {
                    if (profile.name == name)
                    {
                        profileDic[name] = profile;
                        return profile;
                    }
                }
            }
            return null;
        }
        void CreateDic()
        {
            foreach (var texture in profileList)
            {
                profileDic.Add(texture.name, texture);
            }
        }
    }
}
