using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using UnityEditor;

namespace AnimalParty
{
 	public class Xml2Play : MonoBehaviour
	{
        public List<PlayCardData> dataList = new List<PlayCardData>();
        public string xmlFilePath;

        [ContextMenu("RefreshAll")]
        void RefreshAll()
        {
            var reader = FindObjectOfType<XmlReader>();
            reader.SetFilePath(xmlFilePath);
            string[] value;

            for(int i = 0; i < dataList.Count; i++)
            {
                value = reader.ReadLine(i + 1, 6);
                dataList[i].name= value[0];
                dataList[i].cardType = (PlayCardType)(int.Parse(value[1]));
                dataList[i].characterNameList = value[2].Split(new char[] { ',', '£¬' });
                dataList[i].additionalTip = value[3];
                dataList[i].supContent= value[4];
                dataList[i].count = int.Parse(value[5]);
            }

            foreach (var i in dataList)
            {
                EditorUtility.SetDirty(i);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
