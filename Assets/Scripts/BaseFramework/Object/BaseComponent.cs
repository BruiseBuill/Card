using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BF
{
	public abstract class BaseComponent : MonoBehaviour
	{
        protected BaseShareData data;
        protected virtual void Awake()
        {
            data = GetComponentInChildren<BaseShareData>();
        }
        public abstract void Open();
        public abstract void Close();
    }
}