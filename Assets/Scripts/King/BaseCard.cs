using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
	public abstract class BaseCard : MonoBehaviour
	{
		public abstract void SetData(object data);
		public abstract void Load();
	}
}