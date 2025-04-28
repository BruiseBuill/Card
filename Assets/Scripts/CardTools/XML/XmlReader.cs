using System.Collections.Generic;
using System.IO;
using UnityEngine;
using OfficeOpenXml;
using System;

namespace Card
{
    public class XmlReader : MonoBehaviour
    {
        string path;

        public void SetFilePath(string filePath)
        {
            path = Application.dataPath + filePath;
        }
        public string Read(int i, int j)
        {
            FileInfo newFile = new FileInfo(path);
            if (!newFile.Exists)
            {
                Debug.LogError("No such File:Excel");
                return null;
            }

            try
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    // 打开第一个工作表, number in EPPlus is count from 1
                    var worksheet = package.Workbook.Worksheets[1];
                    var value = worksheet.Cells[i, j].Text;
                    return value;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line">count from 1 instead of 0</param>
        /// <param name="length"> </param>
        /// <returns> </returns>
        public string[] ReadLine(int line, int length)
        {
            FileInfo newFile = new FileInfo(path);
            if (!newFile.Exists)
            {
                Debug.LogError("No such File:Excel");
                return null;
            }

            try
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    // 打开第一个工作表, number in EPPlus is count from 1
                    var worksheet = package.Workbook.Worksheets[1];
                    string[] value = new string[length];
                    for (int j = 0; j < length; j++)
                    {
                        value[j] = worksheet.Cells[line, j + 1].Text;
                    }
                    return value;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return null;
            }
        }
    }
}




