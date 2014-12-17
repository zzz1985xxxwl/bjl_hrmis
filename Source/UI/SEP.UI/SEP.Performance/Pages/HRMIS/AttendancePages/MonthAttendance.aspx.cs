using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.AttendanceStatistics.MonthAttendance;
using SEP.Model.Accounts;
using SEP.Presenter.Calendars;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class MonthAttendance : BasePage
    {
        private MyDayAttendancePresenter myDayAttendancePresenter;
        private ShowCalendarDetailPresenter showCalendarDetailPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            MonthAttendancePresenter monthAttendanceBackPresenter =
                new MonthAttendancePresenter(MonthAttendanceView1, LoginUser);
            MonthAttendanceView1.StatisticsAttendance += monthAttendanceBackPresenter.StatisticsEvent;
            monthAttendanceBackPresenter.InitPresenter(IsPostBack);
            MonthAttendanceView1._ShowEmployeeDayAttendanceWindow = ShowEmployeeDayAttendance;
            MonthAttendanceView1.ddlDepartmentSelectedIndexChanged +=
                monthAttendanceBackPresenter.ddlDepartmentSelectedIndexChanged;

            myDayAttendancePresenter = new MyDayAttendancePresenter(MyDayAttendance1, LoginUser);
            MyDayAttendance1._ExecuteSearchEvent += myDayAttendancePresenter.ExecuteSearchEvent;
            MyDayAttendance1.ShowUpdatePanel += ShowMyDayAttendanceWindow;
            MyDayAttendance1.btnCancelOnClientClick = "return CloseModalPopupExtender('" +
                                                      divMPEMyDayAttendance.ClientID + "');";
            MyDayAttendance1.HideUpdatePanel += HideMyDayAttendanceWindow;
            MyDayAttendance1._DateSlection += ShowMyDayAttendanceDetail;

            showCalendarDetailPresenter = new ShowCalendarDetailPresenter(ShowCalendarDetail1, LoginUser);
            ShowCalendarDetail1.btnCancelClick += HideMyDayAttendanceDetailWindow;
            ShowCalendarDetail1.ShowPanel += ShowMyDayAttendanceDetailWindow;
            ShowCalendarDetail1.BtnSendEmailEvent += showCalendarDetailPresenter.SendEmailForEmployees;

        }

        private void HideMyDayAttendanceWindow(object sender, EventArgs e)
        {
            mpeMyDayAttendance.Hide();
        }

        private void ShowMyDayAttendanceWindow(object sender, EventArgs e)
        {
            mpeMyDayAttendance.Show();
        }

        private void ShowMyDayAttendanceDetailWindow(object sender, EventArgs e)
        {
            mpeMyDayAttendance.Show();
            mpeMyDayAttendanceDetail.Show();
        }

        private void HideMyDayAttendanceDetailWindow(object sender, EventArgs e)
        {
            mpeMyDayAttendance.Show();
            mpeMyDayAttendanceDetail.Hide();
        }

        private void ShowMyDayAttendanceDetail(string specialDate)
        {
            ShowCalendarDetail1.Date = specialDate;
            ShowCalendarDetail1.EmployeeInfo = MyDayAttendance1.EmployeeID + ";" + MyDayAttendance1.EmployeeName;
            ShowCalendarDetail1.SetNull();
            showCalendarDetailPresenter.InitPresenter(
                LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A506) != null ||
                LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A503) != null ||
                LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A504) != null, false, false);
            UpdatePanel1.Update();
            ShowMyDayAttendanceDetailWindow(null, null);
        }

        private void ShowEmployeeDayAttendance(string employeeInfo)
        {
            string[] employee = employeeInfo.Split(';');
            MyDayAttendance1.EmployeeID = employee[0];
            MyDayAttendance1.EmployeeName = employee[1] + "�Ŀ���";
            myDayAttendancePresenter.InitPresenter(false, Convert.ToDateTime(MonthAttendanceView1.ScopeDateFrom));
            MyDayAttendance1.EmployeeNameVisible = true;
            MyDayAttendance1.IBtnCloseVisible = true;
            UpdatePanel1.Update();
            mpeMyDayAttendance.Show();
        }


        protected void btnExportServer_Click(object sender, EventArgs e)
        {
            Export("application/ms-excel",
                   MonthAttendanceView1.ScopeDateFrom + "��" + MonthAttendanceView1.ScopeDateTo + ".xls");
        }

        private void Export(string FileType, string FileName)
        {
            //���û�Ӧ״̬
            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition",
                                  "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            Response.ContentType = FileType;
            EnableViewState = false;
            //д���ֽ���
            List<Employee> theEmployeeMonthAttendance = Session["TheEmployeeMonthAttendance"] as List<Employee>;
            bool _IsHours = true;
            try
            {
                _IsHours = Convert.ToBoolean(Session["TheEmployeeMonthAttendance_IsHours"]);
            }
            catch
            {
            }
            StringWriter theExcel = ExportEmployeeAttendanceToExcel(theEmployeeMonthAttendance, _IsHours);
            Response.Write(theExcel.ToString());
            Response.End();
            theExcel.Close();
        }

        private StringWriter ExportEmployeeAttendanceToExcel(List<Employee> employeeAttendenceList, bool ishours)
        {
            List<LeaveRequestType> leaveRequestTypeList = GetLeaveRequestTypeList(employeeAttendenceList);
            StringWriter theMemoryWriter = new StringWriter();


            theMemoryWriter.WriteLine(ExportEmployeeAttendanceTitleToExcel(ishours, leaveRequestTypeList));

            foreach (Employee e in employeeAttendenceList)
            {
                theMemoryWriter.WriteLine(ExportEmployeeAttendanceDataToExcel(e, ishours, leaveRequestTypeList));
            }
            return theMemoryWriter;
        }

        private static string ExportEmployeeAttendanceTitleToExcel(bool ishours,
                                                                   List<LeaveRequestType> leaveRequestTypeList)
        {
            StringBuilder theTitle = new StringBuilder();
            theTitle.Append("Ա������ \t")
                .Append("���� \t")
                .Append("Ӧ������\t")
                .Append("������\t");
            if (!ishours)
            {
                //��
                foreach (LeaveRequestType item in leaveRequestTypeList)
                {
                    theTitle.Append(item.Name + "��D��\t");
                }

                theTitle.Append("������D��\t")
                    .Append("�ٵ����˴���\t")
                    .Append("�ٵ����˷���\t")
                    .Append("�ӰࣨD��\t")
                    .Append("��ͨ�ӰࣨD��\t")
                    .Append("��ͨ�Ӱ��޻��ݣ�D��\t")
                    .Append("��ͨ�Ӱ��û��ݣ�D��\t")
                    .Append("˫���ռӰࣨD��\t")
                    .Append("˫���ռӰ��޻��ݣ�D��\t")
                    .Append("˫���ռӰ��û��ݣ�D��\t")
                    .Append("�����ӰࣨD��\t")
                    //.Append("�����Ӱ��޻��ݣ�D��\t")
                    //.Append("�����Ӱ��û��ݣ�D��\t")
                    .Append("ʣ����ݣ�D��\t")
                    .Append("ʣ����٣�D��\t");
            }
            else
            {
                //Сʱ
                foreach (LeaveRequestType item in leaveRequestTypeList)
                {
                    theTitle.Append(item.Name + "��H��\t");
                }

                theTitle.Append("������H��\t")
                    .Append("�ٵ����˴���\t")
                    .Append("�ٵ����˷���\t")
                    .Append("�ӰࣨH��\t")
                    .Append("��ͨ�ӰࣨH��\t")
                    .Append("��ͨ�Ӱ��޻��ݣ�H��\t")
                    .Append("��ͨ�Ӱ��û��ݣ�H��\t")
                    .Append("˫���ռӰࣨH��\t")
                    .Append("˫���ռӰ��޻��ݣ�H��\t")
                    .Append("˫���ռӰ��û��ݣ�H��\t")
                    .Append("�����ӰࣨH��\t")
                    //.Append("�����Ӱ��޻��ݣ�H��\t")
                    //.Append("�����Ӱ��û��ݣ�H��\t")
                    .Append("ʣ����ݣ�H��\t")
                    .Append("ʣ����٣�H��\t");
            }
            theTitle.Append("������\t");
            theTitle.Append("������������\t");
            theTitle.Append("��ע\t");
            return theTitle.ToString();
        }

        private static string ExportEmployeeAttendanceDataToExcel(Employee e, bool ishours,
                                                                  List<LeaveRequestType> leaveRequestTypeList)
        {
            StringBuilder theAttendance = new StringBuilder();
            theAttendance.Append(e.Account.Name).Append("\t") //("Ա������ \t")
                .Append(e.Account.Dept != null ? e.Account.Dept.Name : "").Append("\t") //("���� \t")
                .Append(e.EmployeeAttendance.MonthAttendance.ExpectedOnDutyDays).Append("\t") //("Ӧ������\t")
                .Append(e.EmployeeAttendance.MonthAttendance.ActualOnDutyDays).Append("\t"); //("������\t")
            if (!ishours)
            {
                //��
                foreach (LeaveRequestType leaveRequestType in leaveRequestTypeList)
                {
                    theAttendance.Append(GetLeaveRequestStatisticsData(leaveRequestType, e, ishours)).Append("\t");
                }

                theAttendance.Append(
                    Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofNoReasonLeave).ToString()).Append("\t")
                    //("������D��\t")
                    .Append(e.EmployeeAttendance.MonthAttendance.LeaveEarly.Count +
                            e.EmployeeAttendance.MonthAttendance.ArriveLate.Count).Append("\t") //("�ٵ����˴���\t")
                    .Append(e.EmployeeAttendance.MonthAttendance.LeaveEarly.TotalData +
                            e.EmployeeAttendance.MonthAttendance.ArriveLate.TotalData).Append("\t") //("�ٵ����˷���\t")
                    .Append(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofOvertime).ToString()).Append(
                    "\t") //("�ӰࣨD��\t")
                    .Append(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofCommonOvertime).ToString()).
                    Append("\t") //("��ͨ�ӰࣨD��\t")
                    .Append(
                    Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofCommonOvertimeNotAdjust).ToString()).
                    Append("\t") //("��ͨ�Ӱ��޻��ݣ�D��\t")
                    .Append(
                    Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofCommonOvertimeAdjust).ToString()).
                    Append("\t") //("��ͨ�Ӱ��û��ݣ�D��\t")
                    .Append(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofWeekendOvertime).ToString()).
                    Append("\t") //("˫���ռӰࣨD��\t")
                    .Append(
                    Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofWeekendOvertimeNotAdjust).ToString()).
                    Append("\t") //("˫���ռӰ��޻��ݣ�D��\t")
                    .Append(
                    Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofWeekendOvertimeAdjust).ToString()).
                    Append("\t") //("˫���ռӰ��û��ݣ�D��\t")
                    .Append(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofHolidayOvertime).ToString()).
                    Append("\t") //("�����ӰࣨD��\t")
                    //.Append(Convert.ToDecimal(EmployeeAttendance.MonthAttendance.DaysofHolidayOvertimeNotAdjust).ToString()).Append("\t")//("�����Ӱ��޻��ݣ�D��\t")
                    //.Append(Convert.ToDecimal(EmployeeAttendance.MonthAttendance.DaysofHolidayOvertimeAdjust).ToString()).Append("\t")//("�����Ӱ��û��ݣ�D��\t")
                    .Append(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained).ToString())
                    .Append("\t") //("ʣ����ݣ�D��\t")
                    .Append(Convert.ToDecimal(e.EmployeeAttendance.Vacation.SurplusDayNum).ToString()).Append("\t");
                //("ʣ����٣�D��\t")
            }
            else
            {
                //Сʱ
                foreach (LeaveRequestType leaveRequestType in leaveRequestTypeList)
                {
                    theAttendance.Append(decimal.Round(GetLeaveRequestStatisticsData(leaveRequestType, e, ishours), 2)).
                        Append("\t");
                }

                theAttendance.Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofNoReasonLeave), 2).
                        ToString()).Append("\t") //("������H��\t")
                    .Append(e.EmployeeAttendance.MonthAttendance.LeaveEarly.Count +
                            e.EmployeeAttendance.MonthAttendance.ArriveLate.Count).Append("\t") //("�ٵ����˴���\t")
                    .Append(e.EmployeeAttendance.MonthAttendance.LeaveEarly.TotalData +
                            e.EmployeeAttendance.MonthAttendance.ArriveLate.TotalData).Append("\t") //("�ٵ����˷���\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofOvertime), 2).ToString())
                    .Append("\t") //("�ӰࣨH��\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofCommonOvertime), 2).
                        ToString()).Append("\t") //("��ͨ�ӰࣨH��\t")
                    .Append(
                    decimal.Round(
                        Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofCommonOvertimeNotAdjust), 2).
                        ToString()).Append("\t") //("��ͨ�Ӱ��޻��ݣ�H��\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofCommonOvertimeAdjust), 2)
                        .ToString()).Append("\t") //("��ͨ�Ӱ��û��ݣ�H��\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofWeekendOvertime), 2).
                        ToString()).Append("\t") //("˫���ռӰࣨH��\t")
                    .Append(
                    decimal.Round(
                        Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofWeekendOvertimeNotAdjust), 2).
                        ToString()).Append("\t") //("˫���ռӰ��޻��ݣ�H��\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofWeekendOvertimeAdjust),
                                  2).ToString()).Append("\t") //("˫���ռӰ��û��ݣ�H��\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofHolidayOvertime), 2).
                        ToString()).Append("\t") //("�����ӰࣨH��\t")
                    //.Append(decimal.Round(Convert.ToDecimal(EmployeeAttendance.MonthAttendance.HoursofHolidayOvertimeNotAdjust), 2).ToString()).Append("\t")//("�����Ӱ��޻��ݣ�H��\t")
                    //.Append(decimal.Round(Convert.ToDecimal(EmployeeAttendance.MonthAttendance.HoursofHolidayOvertimeAdjust), 2).ToString()).Append("\t")//("�����Ӱ��û��ݣ�H��\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained), 2).
                        ToString()).Append("\t") //("ʣ����ݣ�H��\t")
                    .Append(
                    decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.Vacation.SurplusDayNum)*8, 2).ToString()).
                    Append("\t"); //("ʣ����٣�H��\t")
            }
            theAttendance.Append(
                decimal.Round(Convert.ToDecimal(e.EmployeeAttendance.MonthAttendance.RateofOnDuty)*100, 2).ToString()).
                Append("%").Append("\t"); //("������\t");
            return theAttendance.ToString();
        }

        private static decimal GetLeaveRequestStatisticsData(LeaveRequestType leaveRequestType, Employee e, bool ishours)
        {
            foreach (LeaveRequestStatistics item in e.EmployeeAttendance.MonthAttendance.LeaveRequestStatisticsList)
            {
                if (item.LeaveRequestType.LeaveRequestTypeID == leaveRequestType.LeaveRequestTypeID)
                {
                    return ishours ? item.Hours : item.Days;
                }
            }
            return 0;
        }

        private List<LeaveRequestType> GetLeaveRequestTypeList(List<Employee> employeeAttendenceList)
        {
            List<LeaveRequestType> leaveRequestTypeList = new List<LeaveRequestType>();
            foreach (Employee employee in employeeAttendenceList)
            {
                if (employee.EmployeeAttendance == null || employee.EmployeeAttendance.MonthAttendance == null ||
                    employee.EmployeeAttendance.MonthAttendance.LeaveRequestStatisticsList == null)
                {
                    continue;
                }
                foreach (
                    LeaveRequestStatistics leaveRequestStatistics in
                        employee.EmployeeAttendance.MonthAttendance.LeaveRequestStatisticsList)
                {
                    if (
                        LeaveRequestType.FindLeaveRequestType(leaveRequestTypeList,
                                                              leaveRequestStatistics.LeaveRequestType.LeaveRequestTypeID) ==
                        null)
                    {
                        leaveRequestTypeList.Add(leaveRequestStatistics.LeaveRequestType);
                    }
                }
            }

            LeaveRequestType.OrderLeaveRequestType(leaveRequestTypeList);
            return leaveRequestTypeList;
        }
    }
}