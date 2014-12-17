using System;
using SEP.HRMIS.Presenter.AttendanceStatistics.MonthAttendance;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Calendars;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView
{
    public partial class DragMonthAttendanceView : System.Web.UI.UserControl
    {
        private MyDayAttendancePresenter myDayAttendancePresenter;
        private ShowCalendarDetailPresenter showCalendarDetailPresenter;
        
        private string  IsFirstAdd
        {
            get { return ViewState["hfIsFirstAdd"] as string ; }
            set { ViewState["hfIsFirstAdd"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Account LoginUser = Session[SessionKeys.LOGININFO] as Account;
            if (LoginUser == null)
            {
                return;
            }
            MonthAttendancePresenter monthAttendanceFontPresenter =
                new MonthAttendancePresenter(MonthAttendanceView1, LoginUser);
            MonthAttendanceView1.StatisticsAttendance += monthAttendanceFontPresenter.StatisticsEvent;
            if (String.IsNullOrEmpty(IsFirstAdd))
            {monthAttendanceFontPresenter.InitPresenter(false);}
            else 
            {monthAttendanceFontPresenter.InitPresenter(IsPostBack);}
            IsFirstAdd = "IsADDed";

            MonthAttendanceView1._ShowEmployeeDayAttendanceWindow = ShowEmployeeDayAttendance;
            MonthAttendanceView1.ddlDepartmentSelectedIndexChanged +=
                monthAttendanceFontPresenter.ddlDepartmentSelectedIndexChanged;
            MonthAttendanceView1.btnExportClientVisible = false;

            myDayAttendancePresenter = new MyDayAttendancePresenter(MyDayAttendance1, LoginUser);
            MyDayAttendance1._ExecuteSearchEvent += myDayAttendancePresenter.ExecuteSearchEvent;
            MyDayAttendance1.ShowUpdatePanel += ShowMyDayAttendanceWindow;
            MyDayAttendance1.HideUpdatePanel += HideMyDayAttendanceWindow;
            MyDayAttendance1._DateSlection += ShowMyDayAttendanceDetail;
            MyDayAttendance1.btnCancelOnClientClick = "return CloseModalPopupExtender('" + divMPEMyDayAttendance.ClientID + "');";

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
            showCalendarDetailPresenter.InitPresenter(false, false, false);
            UpdatePanel1.Update();
            ShowMyDayAttendanceDetailWindow(null, null);
        }
        private void ShowEmployeeDayAttendance(string employeeInfo)
        {
            string[] employee = employeeInfo.Split(';');
            MyDayAttendance1.EmployeeID = employee[0];
            MyDayAttendance1.EmployeeName = employee[1] + "µÄ¿¼ÇÚ";
            myDayAttendancePresenter.InitPresenter(false, Convert.ToDateTime(MonthAttendanceView1.ScopeDateFrom));
            MyDayAttendance1.EmployeeNameVisible = true;
            MyDayAttendance1.IBtnCloseVisible = true;
            UpdatePanel1.Update();
            mpeMyDayAttendance.Show();
        }
    }
}