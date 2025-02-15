using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Card
{
 	public class ScreenShot : MonoBehaviour
	{
        public Camera camera; // 指定用于截图的相机
        public int width = 256; // 截图的宽度
        public int height = 256; // 截图的高度
        public int x = 100; // 截图起始点的X坐标
        public int y = 100; // 截图起始点的Y坐标
        int count;
        string savePath = "/screenShots";

        public Color borderColor = Color.green; // 边框颜色
        public int borderWidth = 2; // 边框宽度

        private void Awake()
        {
            count = 0;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Capture();
            }
        }
        [ContextMenu("Shot")]
        public void Capture()
        {
            StartCoroutine(CaptureScreenRegion(x, y, width, height));
            count++;
        }
        IEnumerator CaptureScreenRegion(int x, int y, int width, int height)
        {
            // 等待渲染线程结束
            yield return new WaitForEndOfFrame();

            // 创建一个RenderTexture并设置为当前相机的目标
            RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            camera.targetTexture = renderTexture;
            camera.Render();

            // 创建一个新的Texture2D并从RenderTexture中读取像素
            Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
            RenderTexture.active = renderTexture;
            screenShot.ReadPixels(new Rect(x, y, width, height), 0, 0);
            screenShot.Apply();

            // 重置相机的目标纹理和当前的RenderTexture
            camera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(renderTexture);

            // 将Texture2D转换为图片格式，这里使用PNG
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(width, height);

            // 保存图片到文件
            if (!Directory.Exists(string.Format("{0}{1}", Application.dataPath, savePath))) 
            {
                Directory.CreateDirectory(string.Format("{0}{1}", Application.dataPath, savePath));
            }

            File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Saved screenshot to: {0}", filename));
        }

        // 生成截图的文件名
        string ScreenShotName(int width, int height)
        {
            return string.Format("{0}{1}/screen_{2}x{3}_{4}_{5}.png",
                                 Application.dataPath,savePath,
                                 width, height,
                                 System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"), count);
        }

        void OnGUI()
        {
            Rect captureRect = new Rect(x, y, width, height);
            // 绘制边框的上边缘
            GUI.DrawTexture(new Rect(captureRect.xMin, captureRect.yMin, captureRect.width, borderWidth), Texture2D.whiteTexture);
            // 绘制边框的左边缘
            GUI.DrawTexture(new Rect(captureRect.xMin, captureRect.yMin, borderWidth, captureRect.height), Texture2D.whiteTexture);
            // 绘制边框的下边缘
            GUI.DrawTexture(new Rect(captureRect.xMin, captureRect.yMax - borderWidth, captureRect.width, borderWidth), Texture2D.whiteTexture);
            // 绘制边框的右边缘
            GUI.DrawTexture(new Rect(captureRect.xMax - borderWidth, captureRect.yMin, borderWidth, captureRect.height), Texture2D.whiteTexture);

            // 设置边框颜色
            GUI.color = borderColor;

            // 绘制边框的上边缘
            GUI.DrawTexture(new Rect(captureRect.xMin, captureRect.yMin, captureRect.width, borderWidth), Texture2D.whiteTexture);
            // 绘制边框的左边缘
            GUI.DrawTexture(new Rect(captureRect.xMin, captureRect.yMin, borderWidth, captureRect.height), Texture2D.whiteTexture);
            // 绘制边框的下边缘
            GUI.DrawTexture(new Rect(captureRect.xMin, captureRect.yMax - borderWidth, captureRect.width, borderWidth), Texture2D.whiteTexture);
            // 绘制边框的右边缘
            GUI.DrawTexture(new Rect(captureRect.xMax - borderWidth, captureRect.yMin, borderWidth, captureRect.height), Texture2D.whiteTexture);

            // 恢复GUI的颜色设置
            GUI.color = Color.white;
        }
    }
}
