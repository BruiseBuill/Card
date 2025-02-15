using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using UnityEditor;
using System;

namespace AnimalParty
{
 	public class XML2Human : MonoBehaviour
	{
        public List<HumanCardData> dataList;
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
                value = reader.ReadLine(i + 1, 5);
                dataList[i].name = value[0];
                dataList[i].background = value[1];
                dataList[i].perspetive = value[2];
                dataList[i].otherRelation= value[3];
                dataList[i].skill = value[4];
            }

            foreach (var i in dataList)
            {
                EditorUtility.SetDirty(i);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        [ContextMenu("TestNameChange")]
        public void TestNameChange()
        {
            for(int i = 0; i < dataList.Count; i++)
            {
                dataList[i].background = ChangeNameColor(dataList[i].background);
                dataList[i].perspetive = ChangeNameColor(dataList[i].perspetive);
                dataList[i].otherRelation = ChangeNameColor(dataList[i].otherRelation);
            }
            foreach (var i in dataList)
            {
                EditorUtility.SetDirty(i);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        public string ChangeNameColor(string input)
        {
            for(int i = 0; i < dataList.Count; i++)
            {
                input = HighlightTargetString(input, dataList[i].name, dataList[i].Prefix, dataList[i].Suffix);
            }
            return input;
        }
        string HighlightTargetString(string input, string target, string prefix, string suffix)
        {
            while (true)
            {
                // 检查是否存在目标字符串
                if (!input.Contains(target))
                {
                    break;
                }
                
                // 替换目标字符串并添加前缀和后缀
                input = input.Replace(target, $"{prefix}^{suffix}");
            }
            input = input.Replace("^", target);
            return input;
        }
    }
}
