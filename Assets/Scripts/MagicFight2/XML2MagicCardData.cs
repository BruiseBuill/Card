using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using UnityEditor;

namespace MagicFighting2
{
	public class XML2MagicCardData : MonoBehaviour
	{
        public List<MagicCardData> dataList;
        [Tooltip("filePath:/Resource/¡£¡£¡£.xlsx")]
        public string xmlFilePath;

        [ContextMenu("RefreshAll")]
        void RefreshAll()
        {
            var reader = FindObjectOfType<XmlReader>();
            reader.SetFilePath(xmlFilePath);
            string[] value;
            for (int i = 0; i < dataList.Count; i++)
            {
                value = reader.ReadLine(i + 1, 3);

                dataList[i].name = value[0];
                dataList[i].cost = value[1];
                dataList[i].description = value[2];
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