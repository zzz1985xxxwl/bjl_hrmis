using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;
using SEP.Performance.Views;
using DataTable=System.Data.DataTable;
using Page=System.Web.UI.Page;

namespace SEP.Performance.Pages.HRMIS.EmployeeStatisticsPages
{
    public partial class EmployeeStatisticExportPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();

            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);

            if (Session[SessionKeys.EmployeeStaticsOtherStatisticsData] as DataTable != null)
            {
                Worksheet excelSheet2 =
                    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheet2.Name = "其它统计";
                DataTable EmployeeStaticsOtherStatisticsData =
                    Session[SessionKeys.EmployeeStaticsOtherStatisticsData] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(EmployeeStaticsOtherStatisticsData, excelSheet2);
            }


            Worksheet excelSheet1 =
                (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            if (Session[SessionKeys.EmployeeStaticsComeAndLeaveTable] as DataTable != null)
            {
                excelSheet1.Name = "员工统计";
                DataTable employeeStaticsComeAndLeaveTable =
                    Session[SessionKeys.EmployeeStaticsComeAndLeaveTable] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(employeeStaticsComeAndLeaveTable, excelSheet1);
            }
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeStaticsComeAndLeaveBarChart].ToString(),
                                                10, 90);
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeStaticsLeaveRateLineChart].ToString(),
                                                10, 260);
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeStaticsGenderPieChart].ToString(),
                                                10, 420);
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeStaticsEduBgPieChart].ToString(),
                                                300, 420);
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeStaticsWorkAgePieChart].ToString(),
                                                10, 620);
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeStaticsAgePieChart].ToString(),
                                                300, 620);
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                Session[SessionKeys.EmployeeStaticsWorkTypePieChart].ToString(),
                                                10, 820);
            ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                              Session[SessionKeys.EmployeeStaticsPositionGradeTowerTable].ToString(),
                                              300, 820);
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工统计.xls";
            if(File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing, nothing, nothing, nothing, nothing);
            excelBook.Close(false, null, null);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelApp);
            GC.Collect();

            OutputExcel("员工统计");
        }

        private void OutputExcel(string filename)
        {
            string path = Server.MapPath(filename + ".xls");
            FileInfo file = new FileInfo(path);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.UTF8;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name));
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(file.FullName);
            Response.End();
        }
    }
}