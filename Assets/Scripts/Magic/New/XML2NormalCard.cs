using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Card;

namespace MagicFighting
{
    public class XML2NormalCard : MonoBehaviour
    {
        public List<NormalCardData> dataList;
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
                value = reader.ReadLine(i + 1, 7);

                dataList[i].name = value[0];
                dataList[i].Property = (NormalCardProperty)(int.Parse(value[1]));
                dataList[i].count = (int.Parse(value[2]));
                dataList[i].timingForPutting = (int.Parse(value[3]));
                dataList[i].effectCost = value[4];
                dataList[i].effectDescription = value[5];
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