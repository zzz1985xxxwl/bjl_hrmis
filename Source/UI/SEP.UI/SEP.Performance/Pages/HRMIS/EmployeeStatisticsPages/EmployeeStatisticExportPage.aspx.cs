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

namespace SEP.Performance.Pages.HRMIS.EmployeeStatisticsPages
{
    public partial class EmployeeStatisticExportPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var workbook = new HSSFWorkbook();

            if (Session[SessionKeys.EmployeeStaticsComeAndLeaveTable] as DataTable != null)
            {
                DataTable employeeStaticsComeAndLeaveTable =
                    Session[SessionKeys.EmployeeStaticsComeAndLeaveTable] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, employeeStaticsComeAndLeaveTable, "员工统计");
            }
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
                ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsComeAndLeaveBarChart].ToString()),
                true, new int[] { 0, 10, 0, 10 });
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsLeaveRateLineChart].ToString()),
              true, new int[] { 0, 30, 0, 30 });
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsGenderPieChart].ToString()),
              true, new int[] { 0, 50, 0, 50 });
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsEduBgPieChart].ToString()),
              true, new int[] { 0, 70, 0, 70 });
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsWorkAgePieChart].ToString()),
              true, new int[] { 0, 90, 0, 90 });
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsAgePieChart].ToString()),
              true, new int[] { 0, 110, 0, 110 });
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsWorkTypePieChart].ToString()),
              true, new int[] { 0, 130, 0, 130 });
            ExcelUtility.EmbedImage(workbook, workbook.GetSheetAt(0) as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.EmployeeStaticsPositionGradeTowerTable].ToString()),
              true, new int[] { 0, 150, 0, 150 });

            if (Session[SessionKeys.EmployeeStaticsOtherStatisticsData] as DataTable != null)
            {
                DataTable EmployeeStaticsOtherStatisticsData =
                      Session[SessionKeys.EmployeeStaticsOtherStatisticsData] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, EmployeeStaticsOtherStatisticsData, "其它统计");
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            ExcelExportUtility.OutputExcel(Server, Response, "员工统计", ms);
        }


    }
}