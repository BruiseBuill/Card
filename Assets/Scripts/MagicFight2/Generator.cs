using BF;
using Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicFighting2
{
	public class Generator : Single<Generator>
    {
        [SerializeField] List<MagicCardData> dataList = new List<MagicCardData>();

        [Header("Test")]
        [SerializeField] protected GameObject testPrefab;

        [SerializeField] protected GameObject sp_Prefab;
        [SerializeField] protected int testIndex;
        protected int TestIndex
        {
            get
            {
                var a = testIndex;
                testIndex = (testIndex + 1) % (size.x*size.y);
                return a;
            }
        }

        protected ScreenShot screenShot;

        [Header("Alignment")]
        static Vector3 offset = new Vector3(6.3f, 8.8f, 0); 
        static Vector2Int size = new Vector2Int(3, 3);

        [Header("Shot")]
        [SerializeField] float interval=0.9f;
        WaitForSeconds wait_Interval;

        [Header("Profiles")]
        [SerializeField] List<Sprite> profiles;
        Dictionary<string, Sprite> profileDic=new Dictionary<string, Sprite>();
        public Sprite GetProfile(string name)
        {
            if (profileDic == null || profileDic.Count == 0)  
            {
                foreach(var p in profiles)
                {
                    if (p.name == name)
                    {
                        return p;
                    }
                }
                return null;
            }
            else
            {
                return profileDic[name];
            }
        }


        protected List<GameObject> cardGoList = new List<GameObject>();

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
                int r = 0;
                if (int.TryParse(dataList[i].index,out r)) 
                {
                    testPrefab = sp_Prefab;
                }
                var cardGo = Instantiate(testPrefab, GetPos(i - index), Quaternion.identity);
                var card = cardGo.GetComponent<MagicCard>();
                card.SetData(dataList[i]);
                card.Load();
                cardGoList.Add(cardGo);
            }
        }
    }
}