using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Card
{
	public class CharacterCard : MonoBehaviour
	{
		[SerializeField] Character character;
		[SerializeField] Radar radar;
        [Space]
        [SerializeField] Sprite[] genderSprite;
		[SerializeField] SpriteRenderer genderRender;
        [Space]
        [SerializeField] TextMesh nameText;
		[Space]
		[SerializeField] Text skillContent;
		[SerializeField] TextMesh[] titleNum;
		[SerializeField] GameObject[] highLightPoint;
		
		public void SetCharacter(Character character)
		{
			this.character = character;
		}
		[ContextMenu("LoadCard")]
		public void Load()
		{
			if (character == null)
			{
				return;
			}

            genderRender.sprite = character.isMale ? genderSprite[0] : genderSprite[1];
            nameText.text= character.name;

			skillContent.text = character.skill;
			for(int i = 0; i < character.powerPoints.Length; i++)
			{
				titleNum[i].text = character.powerPoints[i].ToString();
            }

			radar.Create(character.powerPoints);
			var mesh = radar.GetComponent<MeshFilter>().sharedMesh;
			for(int i = 1; i < mesh.vertices.Length; i++)
			{
				highLightPoint[i - 1].transform.localPosition = mesh.vertices[i];
            }
        }

	}
}