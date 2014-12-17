using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;
using SEP.Performance.Views;
using DataTable=System.Data.DataTable;
using Page=System.Web.UI.Page;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseStatisticsExportPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Request.QueryString["type"]=="department")
           {
               DepartmentExport();
           }
           else if (Request.QueryString["type"] == "employee")
           {
               EmployeeExport();
           }
        }


        private void DepartmentExport()
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            if (Session[SessionKeys.gvDepartmentStatisticsTableSourceForReimburse] as DataTable != null)
            {
                Worksheet excelSheet1 =
                    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheet1.Name = "������ͳ�Ʊ���";
                DataTable dtgvDepartmentStatisticsTableSource =
                    Session[SessionKeys.gvDepartmentStatisticsTableSourceForReimburse] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvDepartmentStatisticsTableSource, excelSheet1);
                ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                    Session[SessionKeys.DepartmentReimburseStatisticsBarChart].ToString(),
                                                    300, 100);
            }

            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\���ű����ۺ�ͳ��.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            excelApp.Quit();
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelApp);
            GC.Collect();

            OutputExcel("���ű����ۺ�ͳ��");
        }

        private void EmployeeExport()
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            if (Session[SessionKeys.gvEmployeeStatisticsTableSource] as DataTable != null)
            {
                Worksheet excelSheet1 =
                    (Worksheet)excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheet1.Name = "��Ա��ͳ�Ʊ���";
                DataTable dtgvEmployeeStatisticsTableSource =
                    Session[SessionKeys.gvEmployeeStatisticsTableSource] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvEmployeeStatisticsTableSource, excelSheet1);
                ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeReimburseStatisticsBarChart].ToString(),
                                                300, 100);
            }
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\Ա�������ۺ�ͳ��.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            excelApp.Quit();
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelApp);
            GC.Collect();

            OutputExcel("Ա�������ۺ�ͳ��");
        }

        private void OutputExcel(string filename)
        {
            string path = Server.MapPath(filename + ".xls");

            FileInfo file = new FileInfo(path);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.UTF8;
            // ���ͷ��Ϣ��Ϊ"�ļ�����/���Ϊ"�Ի���ָ��Ĭ���ļ��� 
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name));
            // ���ͷ��Ϣ��ָ���ļ���С����������ܹ���ʾ���ؽ��� 
            Response.AddHeader("Content-Length", file.Length.ToString());

            // ָ�����ص���һ�����ܱ��ͻ��˶�ȡ���������뱻���� 
            Response.ContentType = "application/ms-excel";

            // ���ļ������͵��ͻ��� 
            Response.WriteFile(file.FullName);
            // ֹͣҳ���ִ�� 

            Response.End();
        }
    }
}