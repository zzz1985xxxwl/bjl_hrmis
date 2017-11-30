using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.Model.Accounts;
using SEP.Performance.Views;
using DataTable = System.Data.DataTable;
using Page = System.Web.UI.Page;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class InAndOutStatisticsRecordExport : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["type"] != null)
            {
                switch (Request.Params["type"])
                {
                    case "personList":
                        btnExportPersonList();
                        break;
                    default:
                        btnExport();
                        break;
                }
            }
            Response.Write("");
            Response.End();
        }

        private void btnExportPersonList()
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = false;
            List<Worksheet> excelSheetList = new List<Worksheet>();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            if (Session[SessionKeys.PersionInAndOutDataTable] != null)
            {
                Worksheet excelSheet3 =
                    (Worksheet)excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet3);
                excelSheet3.Name = "员工打卡信息";
                List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
                foreach (AttendanceInAndOutRecord record in (List<AttendanceInAndOutRecord>)Session[SessionKeys.PersionInAndOutDataTable])
                {
                    records.Add(record);
                }
                TurnToExcel(records, excelSheet3);
            }
            ExcelExportUtility.RemoveBlankWorkSheet(excelBook);
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工打卡信息.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange,
                             nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(Server, Response, "员工打卡信息");
        }

        private void TurnToExcel(IList<AttendanceInAndOutRecord> attendances, _Worksheet excelSheet)
        {
            List<Employee> employees = CleanAttendanceInAndOutList(attendances);
            int rowCount = employees.Count;
            int colCount = 4;
            object[,] dataArray = new object[rowCount + 1, colCount]; //二维数组定义是多一个标题行。
            dataArray[0, 0] = "员工姓名"; //导出字段标题。
            dataArray[0, 1] = "日期";
            dataArray[0, 2] = "最早打卡时间";
            dataArray[0, 3] = "最晚打卡时间";

            for (int i = 0; i < rowCount; i++)
            {
                dataArray[i + 1, 0] = employees[i].Account.Name;
                dataArray[i + 1, 1] =
                    employees[i].EmployeeAttendance.AttendanceInAndOutStatistics.InTime.ToShortDateString();
                dataArray[i + 1, 2] = employees[i].EmployeeAttendance.AttendanceInAndOutStatistics.InTime.ToShortTimeString();
                DateTime outtime = employees[i].EmployeeAttendance.AttendanceInAndOutStatistics.OutTime;
                dataArray[i + 1, 3] = outtime == Convert.ToDateTime("1900-1-1") ? "" : outtime.ToShortTimeString();
            }
            excelSheet.get_Range("A1", excelSheet.Cells[rowCount + 1, colCount]).Value2 = dataArray;
        }

        private static List<Employee> CleanAttendanceInAndOutList(IList<AttendanceInAndOutRecord> attendances)
        {
            List<Employee> employeeList = new List<Employee>();
            for (int i = 0; i < attendances.Count; i++)
            {
                List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
                records.Add(attendances[i]);
                string employeename = attendances[i].EmployeeName;
                DateTime time = attendances[i].IOTime;
                for (int j = i + 1; j < attendances.Count; j++)
                {
                    if (attendances[j].EmployeeName == employeename && attendances[j].IOTime.Date == time.Date)
                    {
                        records.Add(attendances[j]);
                        attendances.RemoveAt(j);
                        j--;
                    }
                }
                Employee emp = new Employee();
                emp.Account = new Account(0, "", employeename);
                emp.EmployeeAttendance = new EmployeeAttendance();
                DateTime intime = AttendanceInAndOutRecord.FindEarlistTime(records);
                DateTime outtime = AttendanceInAndOutRecord.FindLatestTime(records);
                emp.EmployeeAttendance.AttendanceInAndOutStatistics =
                    new AttendanceInAndOutStatistics(intime, outtime, "");
                employeeList.Add(emp);
            }
            return employeeList;
        }

        private void btnExport()
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = false;
            List<Worksheet> excelSheetList = new List<Worksheet>();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            MemoryStream ms = new MemoryStream();
            if (Session[SessionKeys.InAndOutStatisticsRecordDataTable] as DataTable != null)
            {
                //Worksheet excelSheet3 =
                //    (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //excelSheetList.Add(excelSheet3);
                //excelSheet3.Name = "员工日打卡信息";
                DataTable dtInAndOutStatisticsRecordDataTable =
                    Session[SessionKeys.InAndOutStatisticsRecordDataTable] as DataTable;
                ms = ExcelExportUtility.DataTableTurnToExcel(dtInAndOutStatisticsRecordDataTable);
            }
            //ExcelExportUtility.RemoveBlankWorkSheet(excelBook);
            //object nothing = Type.Missing;
            //object fileFormat = XlFileFormat.xlExcel8;
            //object file = Server.MapPath(".") + "\\员工日打卡信息.xls";
            //if (File.Exists(file.ToString()))
            //{
            //    File.Delete(file.ToString());
            //}
            //excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange,
            //                 nothing, nothing, nothing, nothing, nothing);

            //excelBook.Close(false, null, null);

            //ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            //ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(Server, Response, "员工日打卡信息", ms);
        }
    }
}