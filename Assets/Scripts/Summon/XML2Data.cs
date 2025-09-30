using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using UnityEditor;

namespace Summon
{
 	public class XML2Data : MonoBehaviour
	{
        public List<CardData> dataList;
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

                dataList[i].name = value[2];
                dataList[i].index = value[1];
                dataList[i].attack = value[4];
                dataList[i].defense = value[5];
                dataList[i].introduction = value[3];
                switch (value[6]) 
                {
                    case "1":
                        dataList[i].valueEffect = "<sprite=0>+1";
                        break;
                    case "2":
                        dataList[i].valueEffect = "<sprite=1>+1";
                        break;
                    case "3":
                        dataList[i].valueEffect = "<sprite=0>+2\n<sprite=1>-1";
                        break;
                    case "4":
                        dataList[i].valueEffect = "<sprite=1>+2\n<sprite=0>-1";
                        break;
                    default:
                        dataList[i].valueEffect = "";
                        break;
                }
                dataList[i].profile = Generator.Instance().GetProfile(dataList[i].index);
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
