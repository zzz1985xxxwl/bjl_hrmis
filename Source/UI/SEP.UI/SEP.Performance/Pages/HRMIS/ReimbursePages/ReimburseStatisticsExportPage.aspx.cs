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
                excelSheet1.Name = "按部门统计报销";
                DataTable dtgvDepartmentStatisticsTableSource =
                    Session[SessionKeys.gvDepartmentStatisticsTableSourceForReimburse] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvDepartmentStatisticsTableSource, excelSheet1);
                ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                    Session[SessionKeys.DepartmentReimburseStatisticsBarChart].ToString(),
                                                    300, 100);
            }

            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\部门报销综合统计.xls";
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

            OutputExcel("部门报销综合统计");
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
                excelSheet1.Name = "按员工统计报销";
                DataTable dtgvEmployeeStatisticsTableSource =
                    Session[SessionKeys.gvEmployeeStatisticsTableSource] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvEmployeeStatisticsTableSource, excelSheet1);
                ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeReimburseStatisticsBarChart].ToString(),
                                                300, 100);
            }
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工报销综合统计.xls";
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

            OutputExcel("员工报销综合统计");
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