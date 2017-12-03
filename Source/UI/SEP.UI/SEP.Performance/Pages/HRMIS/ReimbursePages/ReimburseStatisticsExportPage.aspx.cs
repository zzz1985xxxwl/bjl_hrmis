using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;
using SEP.Performance.Views;
using DataTable = System.Data.DataTable;
using Page = System.Web.UI.Page;
using NPOI.HSSF.UserModel;
using SEP.HRMIS.Entity;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseStatisticsExportPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] == "department")
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
            var workbook = new HSSFWorkbook();
            if (Session[SessionKeys.gvDepartmentStatisticsTableSourceForReimburse] as DataTable != null)
            {
                DataTable dtgvDepartmentStatisticsTableSource =
                  Session[SessionKeys.gvDepartmentStatisticsTableSourceForReimburse] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvDepartmentStatisticsTableSource, "������ͳ�Ʊ���");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("������ͳ�Ʊ���") as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.DepartmentReimburseStatisticsBarChart].ToString()),
              true, new int[] { 0, 10, 0, 10 });
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            ExcelExportUtility.OutputExcel(Server, Response, "���ű����ۺ�ͳ��", ms);
        }

        private void EmployeeExport()
        {

            var workbook = new HSSFWorkbook();
            if (Session[SessionKeys.gvEmployeeStatisticsTableSource] as DataTable != null)
            {
                DataTable dtgvDepartmentStatisticsTableSource =
                  Session[SessionKeys.gvEmployeeStatisticsTableSource] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvDepartmentStatisticsTableSource, "��Ա��ͳ�Ʊ���");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("��Ա��ͳ�Ʊ���") as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeReimburseStatisticsBarChart].ToString()),
              true, new int[] { 0, 10, 0, 10 });
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            ExcelExportUtility.OutputExcel(Server, Response, "Ա�������ۺ�ͳ��", ms);
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