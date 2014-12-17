using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;
using SEP.Performance.Views;
using DataTable=System.Data.DataTable;
using Page=System.Web.UI.Page;

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
            GC.Collect();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = false;
            List<Worksheet> excelSheetList = new List<Worksheet>();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            if (Session[SessionKeys.gvTimeSpanStatisticsGroupByParaSource] as DataTable != null)
            {
                Worksheet excelSheet3 =
                    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet3);
                excelSheet3.Name = "按月统计帐套参数";
                DataTable dtgvTimeSpanStatisticsGroupByParaSource =
                    Session[SessionKeys.gvTimeSpanStatisticsGroupByParaSource] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvTimeSpanStatisticsGroupByParaSource, excelSheet3);
                ExcelExportUtility.ImageTurnToExcel(excelSheet3,
                                                    Session[
                                                        SessionKeys.TimeSpanStatisticsGroupByParaLineChartFileNameAndExp
                                                        ].ToString(),
                                                    100, 100);
            }
            if (Session[SessionKeys.gvPositionStatisticsTableSource] as DataTable != null)
            {
                Worksheet excelSheet2 =
                    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet2);
                excelSheet2.Name = "按职位统计工资";
                DataTable dtgvPositionStatisticsTableSource =
                    Session[SessionKeys.gvPositionStatisticsTableSource] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvPositionStatisticsTableSource, excelSheet2);
                ExcelExportUtility.ImageTurnToExcel(excelSheet2,
                                                    Session[SessionKeys.PositionStatisticsBarChartFileNameAndExp].
                                                        ToString(),
                                                    100, 100);
            }
            if (Session[SessionKeys.gvDepartmentStatisticsTableSource] as DataTable != null)
            {
                Worksheet excelSheet1 =
                    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet1);
                excelSheet1.Name = "按部门统计工资";
                DataTable dtgvDepartmentStatisticsTableSource =
                    Session[SessionKeys.gvDepartmentStatisticsTableSource] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvDepartmentStatisticsTableSource, excelSheet1);
                ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                    Session[SessionKeys.DepartmentStatisticsBarChartFileNameAndExp].
                                                        ToString(),
                                                    100, 100);
            }
            ExcelExportUtility.RemoveBlankWorkSheet(excelBook);
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工工资综合统计.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(Server, Response, "员工工资综合统计");
        }

        private void btnAverageExport()
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = false;
            List<Worksheet> excelSheetList = new List<Worksheet>();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            if (Session[SessionKeys.gvTimeSpanStatisticsGroupByDeptSource] as DataTable != null)
            {
                Worksheet excelSheet2 =
                    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet2);
                excelSheet2.Name = "按月统计部门工资";
                DataTable dtgvTimeSpanStatisticsGroupByDeptSource =
                    Session[SessionKeys.gvTimeSpanStatisticsGroupByDeptSource] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvTimeSpanStatisticsGroupByDeptSource, excelSheet2);
                ExcelExportUtility.ImageTurnToExcel(excelSheet2,
                                                    Session[
                                                        SessionKeys.TimeSpanStatisticsGroupByDeptLineChartFileNameAndExp
                                                        ].ToString(),
                                                    100, 100);
            }
            if (Session[SessionKeys.gvAverageStatisticsTableSource] as DataTable != null)
            {
                Worksheet excelSheet1 =
                    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet1);
                excelSheet1.Name = "人均统计";
                DataTable dtgvAverageStatisticsTableSource =
                    Session[SessionKeys.gvAverageStatisticsTableSource] as DataTable;
                ExcelExportUtility.DataTableTurnToExcel(dtgvAverageStatisticsTableSource, excelSheet1);
                ExcelExportUtility.ImageTurnToExcel(excelSheet1,
                                                    Session[SessionKeys.AverageStatisticsBarChartFileNameAndExp].
                                                        ToString(),
                                                    100, 100);
            }
            ExcelExportUtility.RemoveBlankWorkSheet(excelBook);
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工工资人均统计.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(Server, Response, "员工工资人均统计");
        }
    }
}