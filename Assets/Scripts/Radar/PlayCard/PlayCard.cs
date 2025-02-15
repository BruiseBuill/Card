using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Card
{
 	public class PlayCard : MonoBehaviour
	{
        [SerializeField] Act act;

        [SerializeField] TextMesh name;
        [SerializeField] Text description;
        [SerializeField] Image dashLineOfCondition;
        [SerializeField] Text condition;
        [SerializeField] Image dashLineOfRemark;
        [SerializeField] Text remark;
        [SerializeField] TextMesh comment;
        [SerializeField] TextMesh type;


        public void SetAct(Act act)
        {
            this.act = act;
        }

        [ContextMenu("LoadCard")]
        public void Load()
        {
            if (act == null)
            {
                return;
            }

            name.text = act.name;
            
            description.text = act.description;
            //description.GetComponent<ContentSizeFitter>().SetLayoutVertical();
            if (act.condition == "")
            {
                dashLineOfCondition.enabled = false;
                condition.enabled = false;  
            }
            else
            {
                dashLineOfCondition.enabled = true;
                condition.enabled = true;
                condition.text = act.condition;
                //condition.GetComponent<ContentSizeFitter>().SetLayoutVertical();
            }
            if (act.remark == "")
            {
                dashLineOfRemark.enabled = false;
                remark.enabled = false;
            }
            else
            {
                dashLineOfRemark.enabled = true;
                remark.enabled = true;
                remark.text = act.remark;
                //remark.GetComponent<ContentSizeFitter>().SetLayoutVertical();
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(description.transform.parent as RectTransform);
            comment.text = act.comment;
            type.text = act.cardType;
        }

    }
}
