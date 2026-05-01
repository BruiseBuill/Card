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
        [Tooltip("filePath:/Resource/。。。.xlsx")]
        public string xmlFilePath;

        [ContextMenu("RefreshAll")]
        void RefreshAll()
        {
            var reader = FindObjectOfType<XmlReader>();
            reader.SetFilePath(xmlFilePath);
            string[] value;
            for (int i = 0; i < dataList.Count; i++)
            {
                value = reader.ReadLine(i + 1, 9);

                dataList[i].name = value[0];
                dataList[i].effectDescription = value[1];
                dataList[i].rare = (Rare)(int.Parse(value[2]));
                dataList[i].count = int.Parse(value[3]);

                dataList[i].Property = (NormalCardProperty)int.Parse(value[4]);
                dataList[i].kindDescription = value[5];
                dataList[i].timingForPutting = int.Parse(value[6]);
                dataList[i].isSkill = (int.Parse(value[7]) == 1);
                if (dataList[i].isSkill)
                {
                    dataList[i].effectDescription += "<size=30>\n可以重铸此技能牌</size>";
                }
                dataList[i].effectCost = value[8];
                dataList[i].isCostMagic = value[8] != "0";

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