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
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvDepartmentStatisticsTableSource, "按部门统计报销");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("按部门统计报销") as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.DepartmentReimburseStatisticsBarChart].ToString()),
              true, new int[] { 0, 10, 0, 10 });
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            ExcelExportUtility.OutputExcel(Server, Response, "部门报销综合统计", ms);
        }

        private void EmployeeExport()
        {

            var workbook = new HSSFWorkbook();
            if (Session[SessionKeys.gvEmployeeStatisticsTableSource] as DataTable != null)
            {
                DataTable dtgvDepartmentStatisticsTableSource =
                  Session[SessionKeys.gvEmployeeStatisticsTableSource] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvDepartmentStatisticsTableSource, "按员工统计报销");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("按员工统计报销") as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeReimburseStatisticsBarChart].ToString()),
              true, new int[] { 0, 10, 0, 10 });
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            ExcelExportUtility.OutputExcel(Server, Response, "员工报销综合统计", ms);
        }

        private void OutputExcel(string filename)
        {
            string path = Server.MapPath(filename + ".xls");

            FileInfo file = new FileInfo(path);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名 
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度 
            Response.AddHeader("Content-Length", file.Length.ToString());

            // 指定返回的是一个不能被客户端读取的流，必须被下载 
            Response.ContentType = "application/ms-excel";

            // 把文件流发送到客户端 
            Response.WriteFile(file.FullName);
            // 停止页面的执行 

            Response.End();
        }
    }
}