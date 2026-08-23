using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
	public abstract class BaseGenerator : MonoBehaviour
	{
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

        [Header("Alignment")]      
        [SerializeField] protected Vector3 offset = new Vector3(6.3f, 8.8f, 0);
        [SerializeField] protected Vector2Int size = new Vector2Int(3, 3);
        protected List<GameObject> cardGoList = new List<GameObject>();


        [Header("Shot")]
        protected ScreenShot screenShot;
        [SerializeField] protected float interval = 0.8f;
        protected WaitForSeconds wait_Interval;



        protected virtual void Awake()
        {
            screenShot = FindObjectOfType<ScreenShot>();
        }
        protected Vector3 GetPos(int index)
        {
            return new Vector3(-0.5f * size.x * offset.x + (index % size.x) * offset.x, 0.5f * size.y * offset.y - index / size.x * offset.y) + new Vector3(offset.x, -offset.y) * 0.5f;
        }
        
        [ContextMenu("TestLoad")]
        protected void TestLoad()
        {
            GameObject cardGo = Instantiate(testPrefab, GetPos(TestIndex), Quaternion.identity);
            cardGoList.Add(cardGo);
        }

        [ContextMenu("ShotAll")]
        public void Shot()
        {
            StartCoroutine("Shotting");
        }
        protected abstract IEnumerator Shotting();
        protected abstract void LoadOnePage(int index);
        protected void LoadOnePage()
        {
            for (int i = 0;i < size.x * size.y; i++)
            {
                var cardGo = LoadOneCard();
                if (cardGo != null)
                {
                    cardGo.transform.position = GetPos(i);
                    cardGoList.Add(cardGo);
                }                
            }
        }
        protected abstract GameObject LoadOneCard();
    }
}