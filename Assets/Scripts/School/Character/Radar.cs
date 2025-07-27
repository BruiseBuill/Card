using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
	public class Radar : MonoBehaviour
	{
		[Header("BaseSetting")]
		[SerializeField] Vector3 centerPos;
		[SerializeField] int edgeCount;
		[SerializeField] bool isClockwise;
		
		[SerializeField] float firstRayAngle;
		Vector3[] rayOrientArray;
        [SerializeField] float rayLength;
        [SerializeField] float rayLengthOffset;

        [Header("User")]
		[SerializeField] int maxPowerPoint;
		[SerializeField] bool isTest;
		[SerializeField] int[] testPowerPoint;

		[ContextMenu("Create")]
		void Create()
		{
            if (isTest)
            {
				Create(testPowerPoint);
            }
        }
		public void Create(int[] powerPointArray)
		{

			//GetComponent<MeshRenderer>().sortingLayerName = "UI";
			//GetComponent<MeshRenderer>().sortingOrder = 1;

            Mesh mesh = new Mesh();
			GetComponent<MeshFilter>().mesh = mesh;

			var includedAngle = 360f / edgeCount;

			rayOrientArray = new Vector3[edgeCount];
			float angle = firstRayAngle;

            var pointPos = new Vector3[edgeCount];
            for (int i = 0; i < edgeCount; i++)
			{
				rayOrientArray[i] = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

				pointPos[i] = rayLength * powerPointArray[i] / maxPowerPoint * rayOrientArray[i] + centerPos + rayLengthOffset * rayOrientArray[i];
                angle += isClockwise ? -includedAngle : includedAngle;
            }

			Vector3[] vectices = new Vector3[edgeCount + 1];
			vectices[0] = centerPos;
			for(int i = 1; i < vectices.Length; i++)
			{
				vectices[i] = pointPos[i - 1];
			}
			mesh.vertices = vectices;

			int[] triangle = new int[edgeCount * 3];
			for (int i = 0; i < triangle.Length; i += 3) 
			{
				triangle[i] = 0;
				if (isClockwise)
				{
                    triangle[i + 1] = i / 3 + 1;
                    triangle[i + 2] = (i / 3 + 2) > edgeCount ? (i / 3 + 2 - edgeCount) : (i / 3 + 2);
                }
				else
				{
                    triangle[i + 2] = i / 3 + 1;
                    triangle[i + 1] = (i / 3 + 2) > edgeCount ? (i / 3 + 2 - edgeCount) : (i / 3 + 2);
                }
			}
			mesh.triangles = triangle;

			Vector2[] uvs = new Vector2[vectices.Length];
			uvs[0] = new Vector2(0.5f, 0.5f);
			for(int i = 1; i < vectices.Length; i++)
			{
				uvs[i] = uvs[0] + (Vector2)rayOrientArray[i - 1] * powerPointArray[i - 1] / maxPowerPoint*0.5f;
            }
			mesh.uv = uvs;
		}
	}
}