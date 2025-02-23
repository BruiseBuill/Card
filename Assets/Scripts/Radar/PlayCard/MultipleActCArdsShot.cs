using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    [RequireComponent(typeof(ScreenShot))]
 	public class MultipleActCardShot : MonoBehaviour
	{
        [SerializeField] List<Act> actList;
        ScreenShot screenShot;
        [SerializeField] float interval;
        WaitForSeconds wait_Interval;

        private void Awake()
        {
            wait_Interval = new WaitForSeconds(interval);
            screenShot = GetComponent<ScreenShot>();
        }
        [ContextMenu("Shot")]
        void Shot()
        {
            StartCoroutine("Shotting");
        }
        IEnumerator Shotting()
        {
            var playCards = FindObjectsOfType<PlayCard>();
            int actIndex = 0;
            while (true)
            {
                for (int i = 0; i < playCards.Length; i++)
                {
                    if (actIndex < actList.Count)
                    {
                        playCards[i].SetAct(actList[actIndex]);
                        playCards[i].Load();
                    }
                    else
                    {
                        playCards[i].gameObject.SetActive(false);
                    }
                    actIndex++;
                }

                screenShot.Capture();

                yield return wait_Interval;
                if (actIndex >= actList.Count)
                    break;
            }
        }
	}
}
