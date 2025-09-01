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
                value = reader.ReadLine(i + 1, 6);

                dataList[i].name = value[1];
                dataList[i].power = value[2];
                dataList[i].coolDown = value[3];
                if (value[5] != "")
                {
                    dataList[i].description = value[4]+"\n" + value[5];
                }
                else
                {
                    dataList[i].description = value[4];
                }
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