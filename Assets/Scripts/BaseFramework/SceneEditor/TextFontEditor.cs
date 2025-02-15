using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace BF.Tool
{
    public class TextFontEditor : MonoBehaviour
    {
        [SerializeField] List<GameObject> prefabList;
        [SerializeField] TMP_FontAsset defaultFont;
        [SerializeField] List<string> specialTagTextList;
        [SerializeField] List<TMP_FontAsset> specialFontList;

        [ContextMenu("Run")]
        void Run()
        {
            var texts = FindObjectsOfType<TextMeshProUGUI>();
            for (int i = 0; i < texts.Length; i++)
            {
                ChangeFont(texts[i]);
            }

            for(int i = 0; i < prefabList.Count; i++)
            {
                SearchInPrefab(prefabList[i].transform);
                PrefabUtility.SavePrefabAsset(prefabList[i]);
            }
        }
        void SearchInPrefab(Transform prefab)
        {
            List<Transform> trans = new List<Transform>();
            trans.Add(prefab);
            while (trans.Count > 0)
            {
                if(trans[0].TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text))
                {
                    ChangeFont(text);
                }
                for(int i = 0; i < trans[0].childCount; i++)
                {
                    trans.Add(trans[0].GetChild(i));
                }
                trans.RemoveAt(0);
            }
        }
        void ChangeFont(TextMeshProUGUI text)
        {
            if (!specialTagTextList.Contains(text.gameObject.tag))
                text.font = defaultFont;
            else
            {
                text.font = specialFontList[specialTagTextList.IndexOf(text.gameObject.tag)];
            }
        }
    }
}
