using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
	[CreateAssetMenu(menuName ="Card/Character",fileName ="Character")]
	public class Character : ScriptableObject
	{
		public string name;
		public bool isMale;
		public int[] powerPoints;
		[TextArea(1,4)]
		public string skill;
	}
}