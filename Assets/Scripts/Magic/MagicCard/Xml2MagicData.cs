using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Card;

namespace MagicFighting
{
 	public class Xml2MagicData : MonoBehaviour
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
                value = reader.ReadLine(i + 1, 7);
                dataList[i].name = value[0];
                dataList[i].kind = (MagicCardKind)(int.Parse(value[1]));
                dataList[i].count = (int.Parse(value[2]));
                dataList[i].effect_0_MagicCost = value[3];
                dataList[i].effect_0_Description = value[4];
                dataList[i].effect_1_MagicCost = value[5];
                dataList[i].effect_1_Description = value[6];            
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
