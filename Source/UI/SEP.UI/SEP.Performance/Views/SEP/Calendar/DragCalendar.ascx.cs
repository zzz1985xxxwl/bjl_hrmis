using System;
using System.Collections.Generic;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Calendars;

namespace SEP.Performance.Views.SEP.Calendar
{
    public partial class DragCalendar : System.Web.UI.UserControl
    {
        private string employeeID;
        private string employeeName;

        private MyDayAttendancePresenter myDayAttendancePresenter;
        private ShowCalendarDetailPresenter showCalendarDetailPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCalendar();
        }
        private string IsFirstAdd
        {
            get { return ViewState["hfIsFirstAdd"] as string; }
            set { ViewState["hfIsFirstAdd"] = value; }
        }

        public void GetCalendar()
        {
            Account _loginUser = Session[SessionKeys.LOGININFO] as Account;
            if (_loginUser == null||_loginUser.Id==Account.AdminPkid)
            {
                return;
            }
            employeeID = _loginUser.Id.ToString();
            employeeName = _loginUser.Name;
            myDayAttendancePresenter = new MyDayAttendancePresenter(IndexDayAttendance1, null);
            IndexDayAttendance1.EmployeeID = employeeID;
            if (String.IsNullOrEmpty(IsFirstAdd))
            { myDayAttendancePresenter.InitPresenter(false, DateTime.Now); }
            else
            { myDayAttendancePresenter.InitPresenter(IsPostBack, DateTime.Now); }
            IsFirstAdd = "IsADDed";
            IndexDayAttendance1._ExecuteSearchEvent += myDayAttendancePresenter.ExecuteSearchEvent;
            IndexDayAttendance1._DateSlection += ShowDetail;

            showCalendarDetailPresenter = new ShowCalendarDetailPresenter(ShowCalendarDetail1, _loginUser);
            ShowCalendarDetail1.btnCancelClick += HideWindow;
            ShowCalendarDetail1.ShowPanel += ShowWindow;
            ShowCalendarDetail1.RedirectToCalendar += RedirectToCalendar;
            ShowCalendarDetail1.RedirectToRemind += RedirectToRemind;
            ShowCalendarDetail1.BtnSendEmailEvent += showCalendarDetailPresenter.SendEmailForEmployees;

            //ShowCalendarDetail1.InitMultiView += showCalendarDetailPresenter.InitMultiView;
        }
        private void RedirectToCalendar(string date)
        {
            Response.Redirect("../../CRM/AssistancePages/CalendarEventList.aspx?Day=" + date);

        }
        private void RedirectToRemind(string date)
        {
            Response.Redirect("../../CRM/AssistancePages/MyRemind.aspx?Day=" + date);

        }

        private void ShowWindow(object sender, EventArgs e)
        {
            mpespecialDateEdit.Show();
        }
        private void HideWindow(object sender, EventArgs e)
        {
            mpespecialDateEdit.Hide();
            IndexDayAttendance1._DateSlection += ShowDetail;
        }
        private void ShowDetail(string specialDate)
        {
            ShowCalendarDetail1.Date = specialDate;
            ShowCalendarDetail1.EmployeeInfo = employeeID + ";" + employeeName;
            ShowCalendarDetail1.SetNull();
            showCalendarDetailPresenter.InitPresenter(false, true, false);
            mpespecialDateEdit.Show();
        }
    }

}