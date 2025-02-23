using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Card;

namespace MagicFighting
{
 	public class Xml2SkillData : MonoBehaviour
	{
        public List<SkillCardData> dataList;
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
                value = reader.ReadLine(i + 1, 4);
                dataList[i].name = value[0];
                //dataList[i]. = new List<string>() { value[1], value[2], value[3] };
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
