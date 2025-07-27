using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    [RequireComponent(typeof(ScreenShot))]
    public class MultipleCharacterCardsShot : MonoBehaviour
    {
        [SerializeField] List<Character> characterList;
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
            var cards = FindObjectsOfType<CharacterCard>();
            int index = 0;
            while (true)
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    if (index < characterList.Count)
                    {
                        cards[i].SetCharacter(characterList[index]);
                        cards[i].Load();
                    }
                    else
                    {
                        cards[i].gameObject.SetActive(false);
                    }
                    index++;
                }

                screenShot.Capture();

                yield return wait_Interval;
                if (index >= characterList.Count)
                    break;
            }
        }
    }
}
