using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BF
{
    public class GenericEventHandle<T> : ScriptableObject
	{
        protected Action<T> onEvent = delegate { };

        public void Invoke(T t)
        {
            onEvent.Invoke(t);
        }
        public void AddListener(Action<T> action)
        {
            onEvent += action;
        }
        public void RemoveListener(Action<T> action)
        {
            onEvent -= action;
        }
    }
    [CreateAssetMenu(fileName = "EventHandle", menuName = "BF/GenericEventHandle/Int")]
    public class IntEventHandle : GenericEventHandle<int>
    {

    }

    [CreateAssetMenu(fileName = "EventHandle", menuName = "BF/GenericEventHandle/String")]
    public class StringEventHandle : GenericEventHandle<string>
    {
        
    }
}