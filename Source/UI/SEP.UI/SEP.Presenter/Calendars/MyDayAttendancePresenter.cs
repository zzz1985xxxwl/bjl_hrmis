//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewCalendarPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-11
// 概述: 日期
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;
using SEP.Model.Calendar;
using SEP.Model.Utility;
using SEP.Presenter.IPresenter.ICalendar;

namespace SEP.Presenter.Calendars
{
    public class MyDayAttendancePresenter
    {
        private static DateTime _Form;
        private static DateTime _To;
        private readonly Account _Account;
        private readonly Account _LoginUser = HttpContext.Current.Session["LoginInfo"] as Account;
        private Employee _Employee;
        private int _EmployeeID;

        public IEmployeeAttendanceStatisticsFacade _IEmployeeAttendanceStatisticsFacade
            = new EmployeeAttendanceStatisticsFacade();

        public IMyDayAttendance _IMyDayAttendance;

        public MyDayAttendancePresenter(IMyDayAttendance view, Account account)
        {
            _Account = account;
            _IMyDayAttendance = view;
        }

        public void InitPresenter(bool isPostBack, DateTime currentMonth)
        {
            //_IMyDayAttendance.CalendarStatusSet = currentMonth;
            if (!isPostBack)
            {
                ExecuteSearchEvent(currentMonth);
            }
        }

        public void ExecuteSearchEvent(DateTime currentDate)
        {
            if (Validation())
            {
                GetViewCalendar(currentDate);
            }
        }

        public void GetViewCalendar(DateTime currentDate)
        {
            var dttempDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            _Form = dttempDate.AddDays(-14); //月头
            _To = dttempDate.AddMonths(1).AddDays(13); //月末

            var dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("EventStartDate", Type.GetType("System.DateTime"));
            dt.Columns.Add("EventEndDate", Type.GetType("System.DateTime"));
            dt.Columns.Add("EventHeader", Type.GetType("System.String"));
            dt.Columns.Add("EventDescription", Type.GetType("System.String"));
            dt.Columns.Add("EventForeColor", Type.GetType("System.String"));
            dt.Columns.Add("EventBackColor", Type.GetType("System.String"));

            int idCount = 1;

            if (CompanyConfig.HasHrmisSystem && _LoginUser.IsHRAccount)
            {
                List<PlanDutyDetail> planDutyDetailList =
                    _IEmployeeAttendanceStatisticsFacade.GetPlanDutyDetailByAccount(_EmployeeID, _Form, _To);
                if (planDutyDetailList.Count > 0)
                {
                    _IMyDayAttendance.PlanDutyDetailList = planDutyDetailList;
                }

                _Employee =
                    _IEmployeeAttendanceStatisticsFacade.GetCalendarByEmployee(_EmployeeID, _Form, _To, _Account);

                dt = GetHRMISEvents(_Employee, dt, idCount);
            }
            if (CompanyConfig.HasCRMSystem && _LoginUser.IsCRMAccount)
            {
                //List<DayAttendance> crmDayAttendanceList =
                //    _ICalendarEventFacade.GetCalendarByEmployee(_EmployeeID, _Form, _To);
                //dt = GetCRMEvents(crmDayAttendanceList, dt, idCount);
            }
            _IMyDayAttendance.CalendarTable = dt;
            //_IMyDayAttendance.EmployeeName = employee.Account.Name + "的考勤";
            _IMyDayAttendance.CalendarStatusSet = currentDate;
        }

        public bool Validation()
        {
            _IMyDayAttendance.ResultMessage = "";
            bool validation = true;

            if (!int.TryParse(_IMyDayAttendance.EmployeeID, out _EmployeeID))
            {
                _IMyDayAttendance.ResultMessage = "员工ID必须为整数！";
                validation = false;
            }
            return validation;
        }

        private static DataTable GetCRMEvents(IList<DayAttendance> calendarList, DataTable dt, int idCount)
        {
            for (int i = 0; i < calendarList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = idCount++;
                dr["EventStartDate"] = calendarList[i].Date;
                dr["EventEndDate"] = calendarList[i].Date;
                dr["EventHeader"] = calendarList[i].Reason;
                dr["EventDescription"] = calendarList[i].Reason;
                dr["EventForeColor"] = "Green";
                dr["EventBackColor"] = GetColor(calendarList[i].CalendarType);
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private static DataTable GetHRMISEvents(Employee employee, DataTable dt, int idCount)
        {
            List<DayAttendance> calendarList = employee.EmployeeAttendance.DayAttendanceList;

            for (int i = 0; i < calendarList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = idCount++;
                dr["EventStartDate"] = calendarList[i].Date;
                dr["EventEndDate"] = calendarList[i].Date;
                if (calendarList[i].CalendarType == CalendarType.Late ||
                    calendarList[i].CalendarType == CalendarType.LeaveEarly) //如果迟到或早退,显示分钟
                {
                    dr["EventHeader"] = calendarList[i].TypeName + calendarList[i].Minites + "Min";
                }
                else
                {
                    //dr["EventHeader"] = calendarList[i].TypeName + calendarList[i].Days*8 + "小时";
                    dr["EventHeader"] = calendarList[i].TypeName +
                                        Convert.ToSingle(decimal.Round(Convert.ToDecimal(calendarList[i].Hours), 2)) +
                                        "H";
                }
                dr["EventDescription"] = calendarList[i].Reason;
                dr["EventForeColor"] = "Green";
                dr["EventBackColor"] = GetColor(calendarList[i].CalendarType);
                dt.Rows.Add(dr);
            }
            //查看每一天
            DateTime temTime = _Form;
            while (DateTime.Compare(temTime, _To) <= 0)
            {
                //查看这一天员工是否进入公司
                if (DateTime.Compare(employee.EmployeeDetails.Work.ComeDate, temTime) > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = idCount++;
                    dr["EventStartDate"] = temTime;
                    dr["EventEndDate"] = temTime;
                    dr["EventHeader"] = "未入职";
                    dr["EventDescription"] = "未入职";
                    dr["EventForeColor"] = "Green";
                    dr["EventBackColor"] = "#eeeeee";
                    dt.Rows.Add(dr);
                }
                //查看这一天员工是否离开公司
                if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee &&
                    employee.EmployeeDetails.Work.DimissionInfo != null &&
                    DateTime.Compare(employee.EmployeeDetails.Work.DimissionInfo.DimissionDate, temTime) < 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = idCount++;
                    dr["EventStartDate"] = temTime;
                    dr["EventEndDate"] = temTime;
                    dr["EventHeader"] = "离职";
                    dr["EventDescription"] = "离职";
                    dr["EventForeColor"] = "Green";
                    dr["EventBackColor"] = "#eeeeee";
                    dt.Rows.Add(dr);
                }
                temTime = temTime.AddDays(1);
            }
            return dt;
        }

        private static string GetColor(CalendarType type)
        {
            //旷工 fac3ff    请假 c6edff   迟到 fff9c2  外出 bcffb3   加班 9ffffe
            switch (type)
            {
                case CalendarType.Absent:
                    return "#fac3ff";
                case CalendarType.Out:
                    return "#bcffb3";
                case CalendarType.Leave:
                    return "#c6edff";
                case CalendarType.Late:
                case CalendarType.LeaveEarly:
                    return "#fff9c2";
                case CalendarType.OverTime:
                    return "#9ffffe";
                case CalendarType.Remind:
                    return "#CCFF66";
                case CalendarType.CalendarEvent:
                    return "#CCFF99";
                default:
                    return "#FFFFFF";
            }
        }

        //#region 测试用
        //public IGetSpecialDate MockIGetSpecialDate
        //{
        //    set { _IGetSpecialDate = value; }
        //}

        //public IMyAttendanceCalendar MockIGetViewCalendar
        //{
        //    set { _IMyAttendanceCalendar = value; }
        //}
        //#endregion
    }
}