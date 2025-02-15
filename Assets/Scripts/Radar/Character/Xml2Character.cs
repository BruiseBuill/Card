using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Card
{
 	public class Xml2Character : MonoBehaviour
	{
        [SerializeField] List<Character> characters;
        [SerializeField] string xmlFilePath;

        [ContextMenu("RefreshAll")]
        void RefreshAll()
        {
            var reader = FindObjectOfType<XmlReader>();
            reader.SetFilePath(xmlFilePath);
            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].name = reader.Read(i + 1, 1);
                characters[i].isMale = reader.Read(i + 1, 2) == "M";
                characters[i].powerPoints[0] = int.Parse(reader.Read(i + 1, 3));
                characters[i].powerPoints[1] = int.Parse(reader.Read(i + 1, 4));
                characters[i].powerPoints[2] = int.Parse(reader.Read(i + 1, 5));
                characters[i].powerPoints[3] = int.Parse(reader.Read(i + 1, 6));
                var skill = reader.Read(i + 1, 7);
                characters[i].skill = skill;
            }
            

            foreach (var i in characters)
            {
                EditorUtility.SetDirty(i);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
	}
}
