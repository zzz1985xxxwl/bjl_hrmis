//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayAttendance.cs
// 创建者: 王玥琦
// 创建日期: 2008-09-03

// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Calendars;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class DayAttendance : BasePage
    {
        private ShowCalendarDetailPresenter showCalendarDetailPresenter;
        private DayAttendancePresenter dayAttendancePresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A506))
            {
                throw new ApplicationException("没有权限访问");
            }
            dayAttendancePresenter = new DayAttendancePresenter(DayAttendanceView1, LoginUser);
            dayAttendancePresenter.Initialize(IsPostBack);
            DayAttendanceView1._ToButtonSearch = dayAttendancePresenter.SearchDayAttendance;
            DayAttendanceView1._DateSlection += ShowDetail;


            showCalendarDetailPresenter = new ShowCalendarDetailPresenter(ShowCalendarDetail1, LoginUser);
            ShowCalendarDetail1.btnCancelClick += HideWindow;
            ShowCalendarDetail1.ShowPanel += ShowWindow;
            ShowCalendarDetail1.BtnSendEmailEvent += showCalendarDetailPresenter.SendEmailForEmployees;

        }
        private void ShowWindow(object sender, EventArgs e)
        {
            mpeShowCalendarDetail.Show();
        }
        private void HideWindow(object sender, EventArgs e)
        {
            mpeShowCalendarDetail.Hide();
            DayAttendanceView1._DateSlection += ShowDetail;
        }
        private void ShowDetail(string EmployeeInfo, string specialDate, bool isNormal)
        {
            ShowCalendarDetail1.Date = specialDate;
            ShowCalendarDetail1.EmployeeInfo = EmployeeInfo;
            ShowCalendarDetail1.SetNull();
            showCalendarDetailPresenter.InitPresenter(true, false, true);
            mpeShowCalendarDetail.Show();
            return;
            //if (ShowCalendarDetail1.OutApplicationDetailList.Count != 0 ||
            //    ShowCalendarDetail1.OverWorkDetailList.Count!=0 ||
            //    ShowCalendarDetail1.AttendanceBaseList.Count!=0 ||
            //    ShowCalendarDetail1.LeaveRequestList.Count!=0 )
            //{
            //    mpeShowCalendarDetail.Show();
            //    return;
            //}
            //if (!isNormal)
            //{
            //    Response.Redirect("InAndOutDetailListView.aspx?" + ConstParameters.EmployeeId + "=" +
            //      SecurityUtil.DECEncrypt(employeeID.Split(';')[0]) + "&" +
            //      ConstParameters.DepartmentID + "=" + SecurityUtil.DECEncrypt("-1") + "&" +
            //       ConstParameters.SearchFrom + "=" + SecurityUtil.DECEncrypt(specialDate + " 0:00:00") + "&" +
            //        ConstParameters.SearchTo + "=" + SecurityUtil.DECEncrypt(specialDate + " 23:59:59"));
            //}
        }

        protected void btnExportServer_Click(object sender, EventArgs e)
        {
            Export("application/ms-excel", "日考勤详情"+DayAttendanceView1.FromDate + "～" + DayAttendanceView1.ToDate+ ".xls");
        }

        private void Export(string FileType, string FileName)
        {
            //设置回应状态
            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition",
                                  "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            Response.ContentType = FileType;
            EnableViewState = false;
            //写入字节流
 
            EmployeeCollection theEmployees = new EmployeeCollection();
            theEmployees.DayAttendanceWeek1List = Session["TheEmployeeDayAttendanceWeek1List"] as List<Employee>;
            theEmployees.DayAttendanceWeek2List = Session["TheEmployeeDayAttendanceWeek2List"] as List<Employee>;
            theEmployees.DayAttendanceWeek3List = Session["TheEmployeeDayAttendanceWeek3List"] as List<Employee>;
            theEmployees.DayAttendanceWeek4List = Session["TheEmployeeDayAttendanceWeek4List"] as List<Employee>;
            theEmployees.DayAttendanceWeek5List = Session["TheEmployeeDayAttendanceWeek5List"] as List<Employee>;
            theEmployees.DayAttendanceWeek6List = Session["TheEmployeeDayAttendanceWeek6List"] as List<Employee>;

            theEmployees.Week1List = Session["TheEmployeeWeek1List"] as List<string>;
            theEmployees.Week2List = Session["TheEmployeeWeek2List"] as List<string>;
            theEmployees.Week3List = Session["TheEmployeeWeek3List"] as List<string>;
            theEmployees.Week4List = Session["TheEmployeeWeek4List"] as List<string>;
            theEmployees.Week5List = Session["TheEmployeeWeek5List"] as List<string>;
            theEmployees.Week6List = Session["TheEmployeeWeek6List"] as List<string>;

            StringWriter theExcel = theEmployees.ExportEmployeeDayAttendanceToExcel();
            
            Response.Write(theExcel.ToString());
            Response.End();
            theExcel.Close();
        }
    }
}
