using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Card
{
 	public class Xml2Act : MonoBehaviour
	{
        [SerializeField] List<Act> acts = new List<Act>();
        [SerializeField] string xmlFilePath;

        [ContextMenu("RefreshAll")]
        void RefreshAll()
        {
            var reader = FindObjectOfType<XmlReader>();
            reader.SetFilePath(xmlFilePath);
            string[] value; 
            for (int i = 0; i < acts.Count; i++)
            {
                value = reader.ReadLine(i + 1, 6);
                acts[i].name = value[0];
                var description = value[1];
                description = "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0" + description;
                description = description.Replace("#", "\n\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0");
                acts[i].description = description;
                
                if (value[2].Length > 0) 
                {
                    acts[i].condition = value[2];
                }
                if (value[3].Length > 0)
                {
                    acts[i].remark = value[3];
                }
                if (value[4].Length > 0)
                {
                    acts[i].comment = value[4];
                }
                acts[i].cardType = value[5];                
            }
            foreach(var i in acts)
            {
                EditorUtility.SetDirty(i);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
