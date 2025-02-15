using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using UnityEditor;

namespace AnimalParty
{
 	public class Xml2Character : MonoBehaviour
	{
        public List<CharacterCardData> dataList;
        [Tooltip("filePath:/Resource/¡£¡£¡£.xlsx")]
        public string xmlFilePath;

        [ContextMenu("RefreshAll")]
        void RefreshAll()
        {
            var reader = FindObjectOfType<XmlReader>();
            reader.SetFilePath(xmlFilePath);
            string[] value;
            for(int i = 0; i < dataList.Count; i++)
            {
                value = reader.ReadLine(i + 1, 4);
                dataList[i].name= value[0];
                dataList[i].foodName = new List<string>() { value[1], value[2], value[3] };
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
