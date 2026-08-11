using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using UnityEditor;

namespace Synthesis
{
    public class XML2CardData : MonoBehaviour
    {
        public List<TreasureData> dataList;
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
                value = reader.ReadLine(i + 2, 10);
                dataList[i].name = value[0];
                dataList[i].colorIndex= Match(value[1]);
                dataList[i].effect = value[5];
                dataList[i].count = int.Parse(value[6]);
                dataList[i].synthesisScore = value[7];
                dataList[i].hardScore = value[9];
            }

            foreach (var i in dataList)
            {
                EditorUtility.SetDirty(i);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        int Match(string value)
        {
            if (value == "R")
            {
                return 0;
            }
            else if (value == "Y")
            {
                return 1;
            }
            else if (value == "B")
            {
                return 2;
            }
            else if (value == "W")
            {
                return 3;
            }
            else 
            {
                return 4;
            }
        }
    }
}