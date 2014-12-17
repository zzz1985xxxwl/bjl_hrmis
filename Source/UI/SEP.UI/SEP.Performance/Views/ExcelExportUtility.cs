//���³�����http://www.diybl.com/course/4_webprogram/asp.net/netjs/2008917/143216_2.html
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace SEP.Performance.Views
{
    public class ExcelExportUtility
    {
        private static string[] Letters =
    new string[]
                {
                    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U"
                    , "V", "W", "X", "Y", "Z"
                };

        private static List<string> _ExcelColumnNames;
        public static List<string> ExcelColumnNames
        {
            get
            {
                if (_ExcelColumnNames != null)
                {
                    return _ExcelColumnNames;
                }
                List<string> names = new List<string>();
                for (int i = 0; i < Letters.Length; i++)
                {
                    names.Add(Letters[i]);
                }
                for (int i = 0; i < Letters.Length; i++)
                {
                    for (int j = 0; j < Letters.Length; j++)
                    {
                        names.Add(Letters[i] + Letters[j]);
                    }
                }
                _ExcelColumnNames = names;
                return _ExcelColumnNames;
            }
        }


        private const float ExcelImageRate = (float)0.75;
        public static void DataTableTurnToExcel(System.Data.DataTable dt, _Worksheet excelSheet)
        {
            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            object[,] dataArray = new object[rowCount + 1, colCount]; //��ά���鶨���Ƕ�һ�������С�
            for (int j = 0; j < colCount; j++)
            {
                dataArray[0, j] = dt.Columns[j].Caption == "." ? "" : dt.Columns[j].Caption; //�����ֶα��⡣
                //���ݸ��е�������������Excel�ĸ�ʽ��
                //switch (dt.Columns[j].DataType.ToString()) //��ʽ����Ԫ��������ʽ
                //{
                //    case "System.String":
                //        excelSheet.get_Range(excelSheet.Cells[1, 1 + j], excelSheet.Cells[rowCount + 1, 1 + j]).
                //            NumberFormatLocal = "@";
                //        break;
                //    case "System.Decimal":
                //        excelSheet.get_Range(excelSheet.Cells[1, 1 + j], excelSheet.Cells[rowCount + 1, 1 + j]).
                //            NumberFormatLocal = "$0.00";
                //        break;
                //    case "System.DateTime":
                //        excelSheet.get_Range(excelSheet.Cells[1, 1 + j], excelSheet.Cells[rowCount + 1, 1 + j]).
                //            NumberFormatLocal = "yyyy-mm-dd";
                //        break;
                //    //���Ը����Լ�����Ҫ��չ��
                //    default:
                //        excelSheet.get_Range(excelSheet.Cells[1, 1 + j], excelSheet.Cells[rowCount + 1, 1 + j]).
                //            NumberFormatLocal = "G/ͨ�ø�ʽ";
                //        break;
                //}
                for (int i = 0; i < rowCount; i++)
                {
                    dataArray[i + 1, j] = dt.Rows[i][j];
                }
            }
            excelSheet.get_Range("A1", excelSheet.Cells[rowCount + 1, colCount]).Value2 = dataArray;

        }

        public static void OutputExcel( string fileallpath, HttpServerUtility server, HttpResponse response)
        {
            //string path = server.MapPath(filename + ".xls");

            FileInfo file = new FileInfo(fileallpath);
            response.Clear();
            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.UTF8;
            // ���ͷ��Ϣ��Ϊ"�ļ�����/���Ϊ"�Ի���ָ��Ĭ���ļ��� 
            response.AddHeader("Content-Disposition", "attachment; filename=" + server.UrlEncode(file.Name));
            // ���ͷ��Ϣ��ָ���ļ���С����������ܹ���ʾ���ؽ��� 
            response.AddHeader("Content-Length", file.Length.ToString());

            // ָ�����ص���һ�����ܱ��ͻ��˶�ȡ���������뱻���� 
            response.ContentType = "application/ms-excel";

            // ���ļ������͵��ͻ��� 
            response.WriteFile(file.FullName);
            // ֹͣҳ���ִ�� 

            response.End();
        }


        public static void OutputExcel(System.Web.HttpServerUtility server, System.Web.HttpResponse response, string filename)
        {
            string path = server.MapPath(filename + ".xls");

            FileInfo file = new FileInfo(path);
            response.Clear();
            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.UTF8;
            // ���ͷ��Ϣ��Ϊ"�ļ�����/���Ϊ"�Ի���ָ��Ĭ���ļ��� 
            response.AddHeader("Content-Disposition", "attachment; filename=" + server.UrlEncode(file.Name));
            // ���ͷ��Ϣ��ָ���ļ���С����������ܹ���ʾ���ؽ��� 
            response.AddHeader("Content-Length", file.Length.ToString());

            // ָ�����ص���һ�����ܱ��ͻ��˶�ȡ���������뱻���� 
            response.ContentType = "application/ms-excel";

            // ���ļ������͵��ͻ��� 
            response.WriteFile(file.FullName);
            // ֹͣҳ���ִ�� 

            response.End();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        public static void KillProcess(Application excelApp, string processName)
        {
            //�õ����д򿪵Ľ���
            try
            {
                if (excelApp != null)
                {
                    int lpdwProcessId;
                    GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), out lpdwProcessId);

                    Process.GetProcessById(lpdwProcessId).Kill();
                }
            }
            catch// (Exception Exc)
            {
                //throw new Exception("", Exc);
            }
        }

        public static void ReleaseComObject(Application excelApp, Workbook excelBook, List<Worksheet> excelSheetList)
        {
            excelApp.Quit();

            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            for (int i = 0; i < excelSheetList.Count; i++)
            {
                Marshal.ReleaseComObject(excelSheetList[i]);
                excelSheetList[i] = null;
            }
            excelBook = null;
            excelApp = null;
            GC.Collect(0);
        }

        public static void ImageTurnToExcel(Worksheet worksheet, string imageNameAndExp, int left, int top)
        {
            try
            {
                string imagePath = HttpContext.Current.Request.PhysicalApplicationPath + @"Pages\image\imageZedGraph\" +
                                   imageNameAndExp;
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                worksheet.Shapes.AddPicture(imagePath, MsoTriState.msoFalse, MsoTriState.msoCTrue, left, top,
                                            image.Width * ExcelImageRate,
                                            image.Height * ExcelImageRate);
            }
            catch
            {
            }
        }

        public static void RemoveBlankWorkSheet(Workbook workbook)
        {
            if(workbook.Worksheets.Count>3)
            {
                //((Worksheet)workbook.Worksheets[0]).Delete();
                //((Worksheet)workbook.Worksheets[1]).Delete();
                //((Worksheet)workbook.Worksheets[2]).Delete(); 
            }
        }

        public delegate void ExportContent(Application excel);

        public static FileInfo NormalExport(string FileName, ExportContent ImplementExportContent)
        {
            GC.Collect();
            string tempdirectory = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(tempdirectory))
            {
                Directory.CreateDirectory(tempdirectory);
            }
            string templocation = tempdirectory + "\\" + FileName;
            Application excel = new Application();
            _Workbook xBk = excel.Workbooks.Add(Type.Missing);
            _Worksheet xSt = (_Worksheet) xBk.ActiveSheet;

            try
            {
                if (ImplementExportContent != null)
                {
                    ImplementExportContent(excel);
                }
                object nothing = Type.Missing;
                object fileFormat = XlFileFormat.xlExcel8;
                object file1 = templocation;
                if (File.Exists(file1.ToString()))
                {
                    File.Delete(file1.ToString());
                }
                xBk.SaveAs(file1, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing,
                           nothing, nothing, nothing, nothing);
            }
            finally
            {
                xBk.Close(false, null, null);
                excel.Quit();
                Marshal.ReleaseComObject(xBk);
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(xSt);
                GC.Collect();
            }
            FileInfo file = new FileInfo(templocation);
            return file;
        }


        public static void OutputExcelByTemplocation(HttpServerUtility server, HttpResponse response, Application excelapp, _Workbook xBk, _Worksheet xSt, string fileName)
        {
            string tempdirectory = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(tempdirectory))
            {
                Directory.CreateDirectory(tempdirectory);
            }
            string templocation = tempdirectory + "\\" + fileName;
            try
            {
                object nothing = Type.Missing;
                object fileFormat = XlFileFormat.xlExcel8;
                object file = templocation;
                if (File.Exists(file.ToString()))
                {
                    File.Delete(file.ToString());
                }
                xBk.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing,
                           nothing, nothing, nothing, nothing);
            }
            finally
            {
                xBk.Close(false, null, null);
                excelapp.Quit();
                Marshal.ReleaseComObject(xBk);
                Marshal.ReleaseComObject(excelapp);
                Marshal.ReleaseComObject(xSt);
                GC.Collect();
            }
            FileInfo fileInfo = new FileInfo(templocation);
            if (fileInfo.Exists)
            {
                response.Clear();
                response.Charset = "GB2312";
                response.ContentEncoding = Encoding.UTF8;
                response.AddHeader("Content-Disposition",
                                   "attachment; filename=" + server.UrlEncode(fileInfo.Name));
                response.AddHeader("Content-Length", fileInfo.Length.ToString());
                response.ContentType = "application/ms-excel";
                response.WriteFile(fileInfo.FullName);
                response.End();
            }
        }

    }
}
