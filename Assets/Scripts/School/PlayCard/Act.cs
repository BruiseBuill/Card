using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName ="Act",menuName ="Card/Act")]

 	public class Act : ScriptableObject
	{
        public string name;
        public string description;
        public string condition;
        public string remark;

        public string comment;
        public string cardType;
	}
}
