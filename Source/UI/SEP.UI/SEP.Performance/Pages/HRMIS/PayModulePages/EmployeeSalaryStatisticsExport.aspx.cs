using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;
using SEP.Performance.Views;
using DataTable = System.Data.DataTable;
using Page = System.Web.UI.Page;
using SEP.HRMIS.Entity;
using NPOI.HSSF.UserModel;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class EmployeeSalaryStatisticsExport : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] == "SummaryExport")
            {
                btnSummaryExport();
            }
            else if (Request.QueryString["type"] == "AverageExport")
            {
                btnAverageExport();
            }
        }

        private void btnSummaryExport()
        {
            var workbook = new HSSFWorkbook();
            if (Session[SessionKeys.gvTimeSpanStatisticsGroupByParaSource] as DataTable != null)
            {
                DataTable dtgvTimeSpanStatisticsGroupByParaSource =
                  Session[SessionKeys.gvTimeSpanStatisticsGroupByParaSource] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvTimeSpanStatisticsGroupByParaSource, "按月统计帐套参数");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("按月统计帐套参数") as HSSFSheet,
              ExcelExportUtility.GetImagePath(Session[SessionKeys.TimeSpanStatisticsGroupByParaLineChartFileNameAndExp].ToString()),
              true, new int[] { 0, 10, 0, 10 });
            }
            if (Session[SessionKeys.gvPositionStatisticsTableSource] as DataTable != null)
            {
                DataTable dtgvPositionStatisticsTableSource =
              Session[SessionKeys.gvPositionStatisticsTableSource] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvPositionStatisticsTableSource, "按职位统计工资");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("按职位统计工资") as HSSFSheet,
           ExcelExportUtility.GetImagePath(Session[SessionKeys.PositionStatisticsBarChartFileNameAndExp].ToString()),
           true, new int[] { 0, 10, 0, 10 });


            }
            if (Session[SessionKeys.gvDepartmentStatisticsTableSource] as DataTable != null)
            {
                DataTable dtgvDepartmentStatisticsTableSource =
                   Session[SessionKeys.gvDepartmentStatisticsTableSource] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvDepartmentStatisticsTableSource, "按部门统计工资");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("按部门统计工资") as HSSFSheet,
        ExcelExportUtility.GetImagePath(Session[SessionKeys.DepartmentStatisticsBarChartFileNameAndExp].ToString()),
        true, new int[] { 0, 10, 0, 10 });

            }

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            ExcelExportUtility.OutputExcel(Server, Response, "员工工资综合统计", ms);
        }

        private void btnAverageExport()
        {
            var workbook = new HSSFWorkbook();
            if (Session[SessionKeys.gvTimeSpanStatisticsGroupByDeptSource] as DataTable != null)
            {
                DataTable dtgvTimeSpanStatisticsGroupByDeptSource =
                   Session[SessionKeys.gvTimeSpanStatisticsGroupByDeptSource] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvTimeSpanStatisticsGroupByDeptSource, "按月统计部门工资");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("按月统计部门工资") as HSSFSheet,
        ExcelExportUtility.GetImagePath(Session[SessionKeys.TimeSpanStatisticsGroupByDeptLineChartFileNameAndExp].ToString()),
        true, new int[] { 0, 10, 0, 10 });
            }
            if (Session[SessionKeys.gvAverageStatisticsTableSource] as DataTable != null)
            {
                DataTable dtgvAverageStatisticsTableSource =
                  Session[SessionKeys.gvAverageStatisticsTableSource] as DataTable;
                ExcelUtility.RenderDataTableToExcel(workbook, dtgvAverageStatisticsTableSource, "人均统计");
                ExcelUtility.EmbedImage(workbook, workbook.GetSheet("人均统计") as HSSFSheet,
        ExcelExportUtility.GetImagePath(Session[SessionKeys.AverageStatisticsBarChartFileNameAndExp].ToString()),
        true, new int[] { 0, 10, 0, 10 });


            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            ExcelExportUtility.OutputExcel(Server, Response, "员工工资人均统计", ms);
        }
    }
}