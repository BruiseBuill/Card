using System;
using System.IO;
using OfficeOpenXml;  // 引入EPPlus命名空间
using UnityEngine;
 
namespace Card
{
    public class Txt2Xml:MonoBehaviour
    {
        [Tooltip("DataPath:。。。/Assets, filePath:/Resource/。。。.txt")]
        [SerializeField] string txtFilePath;
        [SerializeField] string excelFilePath;

        [ContextMenu(@"Col:。  Row\n")]
        public void ConvertTextToExcel()
        {
            var txtPath = Application.dataPath + txtFilePath;
            var xmlPath = Application.dataPath + excelFilePath;

            string[] lines = File.ReadAllLines(txtPath);

            // 创建一个新的Excel包
            using (var package = new ExcelPackage())
            {
                // 添加一个新的工作表
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                int row = 1;  // Excel文件的行号开始于1
                foreach (var line in lines)
                {
                    int col = 1;  // Excel文件的列号也开始于1

                    // 使用冒号和句号作为分隔符
                    string[] cells = line.Split(new char[] { ':','：','。' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var cell in cells)
                    {
                        // 将文本写入单元格
                        worksheet.Cells[row, col].Value = cell.Trim();
                        col++;
                    }

                    row++;
                }
               
                // 保存Excel文件
                FileInfo fi = new FileInfo(xmlPath);
                if (fi.Exists)
                {
                    fi.Delete();  // 确保创建新工作簿  
                    fi = new FileInfo(xmlPath);
                }
                package.SaveAs(fi);
            }
        }

        //Divide Col By:"\n"，Row By"\n\n", delete line content when lineLength<=1(Sometimes you need to align column)
        [ContextMenu(@"Col\n  Row\n\n  Replace# to \n")]
        public void Convert()
        {
            var txtPath = Application.dataPath + txtFilePath;
            var xmlPath = Application.dataPath + excelFilePath;
            string[] lines = File.ReadAllLines(txtPath);

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                int row = 1, col = 1;

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // 如果遇到一个空行，则移动到下一行的开始
                        row++;
                        col = 1;
                    }
                    else
                    {
                        if (line.Length > 1)
                            worksheet.Cells[row, col].Value = line.Replace("#", "\n");
                        col++; // 向右移动一列
                    }
                }
                // 保存Excel文件
                FileInfo fi = new FileInfo(xmlPath);
                if (fi.Exists)
                {
                    fi.Delete();  // 确保创建新工作簿  
                    fi = new FileInfo(xmlPath);
                }
                package.SaveAs(fi);
            }            
        }
    }
}

