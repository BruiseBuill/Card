using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace King
{
    [CreateAssetMenu(fileName = "EventCardData", menuName = "King/EventCardData")]
    public class EventCardData : MonoBehaviour
	{
        new public string name;

        public int count;
        public string introduction;

    }
}