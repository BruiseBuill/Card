using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
	public class BaseGenerator : MonoBehaviour
	{
        [Header("Test")]
        [SerializeField] protected GameObject testPrefab;
        [SerializeField] int testIndex;
        protected int TestIndex
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

        protected ScreenShot screenShot;

        [Header("Alignment")]
        static Vector3 offset = new Vector3(6.3f, 8.8f, 0);
        [SerializeField] protected bool isLoadingSkillCard;
        protected static List<Vector3> cardPosList = new List<Vector3>() { new Vector3(-offset.x,offset.y),new Vector3(0,offset.y),offset,
                new Vector3(-offset.x,0),Vector3.zero, new Vector3(offset.x,0),
                -offset,new Vector3(0,-offset.y),new Vector3(offset.x,-offset.y)};

        List<GameObject> cardGoList = new List<GameObject>();

        protected void Awake()
        {
            screenShot = FindObjectOfType<ScreenShot>();
        }
        [ContextMenu("TestLoad")]
        void TestLoad()
        {
            GameObject cardGo = Instantiate(testPrefab, cardPosList[TestIndex], Quaternion.identity);
            cardGoList.Add(cardGo);
        }
    }
}