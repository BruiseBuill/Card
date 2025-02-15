using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BF
{
	public abstract class BaseControl : MonoBehaviour
	{
		protected BaseShareData data;
		public bool IsAlive
		{
			protected set => data.isAlive.Value = value;
            get => data.isAlive.Value;
		}
		protected virtual void Awake()
		{
			data = GetComponentInChildren<BaseShareData>();
		}
        public abstract void Close();
	}
}