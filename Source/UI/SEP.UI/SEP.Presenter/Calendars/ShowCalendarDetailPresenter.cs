//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ShowCalendarDetailPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-07
// 概述: 
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Utility;
using SEP.Presenter.IPresenter.ICalendar;

namespace SEP.Presenter.Calendars
{
    public class ShowCalendarDetailPresenter
    {
        public IShowCalendarDetail _IShowCalendarDetail;
        public IEmployeeAttendanceStatisticsFacade _IEmployeeAttendanceStatisticsFacade
            = InstanceFactory.CreateEmployeeAttendanceStatisticsFacade();

        private readonly IAttendanceInOutRecordFacade _IAttendanceInOutRecordFacade =
            InstanceFactory.AttendanceInOutRecordFacade;
            
        //public ICalendarEventFacade _ICalendarEventFacade =
        //    FacadeInstance.CreateCalendarEventFacade();
        private DateTime _Date;
        private int _EmployeeID;
        private readonly Account _LoginUser;
        public ShowCalendarDetailPresenter(IShowCalendarDetail view ,  Account loginUser)
        {
            _IShowCalendarDetail = view;
            _LoginUser = loginUser;
        }

        public void SendEmailForEmployees()
        {
            try
            {
                string[] temp = _IShowCalendarDetail.EmployeeInfo.Split(';');
                string employeeName = temp[1];
                string status = "";
                if (temp.Length>2)
                {
                    status = temp[3];
                }
                int.TryParse(temp[0], out _EmployeeID);
                List<string> cc = new List<string>();
                IBll.Accounts.IAccountBll _IGetEmployee = BllInstance.AccountBllInstance;
                Account account = _IGetEmployee.GetAccountById(_EmployeeID);
                if (account == null)
                {
                    return;
                }
                List<string> to = new List<string>();
                to.Add(account.Email1);
                if (!string.IsNullOrEmpty(account.Email2))
                {
                    to.Add(account.Email2);
                }
                if (!DateTime.TryParse(_IShowCalendarDetail.Date, out _Date))
                {
                    _IShowCalendarDetail.ResultMessage = "请选择一个日期！";
                    return;
                }
                List<AttendanceInAndOutRecord> _AttendanceInAndOutRecordList = _IAttendanceInOutRecordFacade.GetSelfAttendanceInAndOutRecordByCondition(_EmployeeID, _Date,
                                                                         _Date.AddDays(1).AddMinutes(-1));
                DateTime e = AttendanceInAndOutRecord.FindEarlistTime(_AttendanceInAndOutRecordList);
                DateTime l = AttendanceInAndOutRecord.FindLatestTime(_AttendanceInAndOutRecordList);
                string inTime = e == Convert.ToDateTime("2999-12-31") ? "无" : e.ToString();
                string outTime = l == Convert.ToDateTime("1900-1-1") ? "无" : l.ToString();

                IAttendanceReadDataFacade _IAttendanceReadDataFacade = InstanceFactory.CreateAttendanceReadDataFacade();
                _IAttendanceReadDataFacade.AttendanceSendEmailToEmployee(employeeName, inTime, outTime, status,
                                                       new DateTime(_Date.Year, _Date.Month, _Date.Day, 0, 0, 0).ToString(), new DateTime(_Date.Year, _Date.Month, _Date.Day, 23, 59, 59).ToString(), to, cc, _LoginUser);

                _IShowCalendarDetail.ResultMessage = "邮件已发送";
            }
            catch (Exception ex)
            {
                _IShowCalendarDetail.ResultMessage = ex.Message;
            }
        }
        public void InitPresenter(bool isShowBtn,bool isShowCRM , bool isShowSendEmail)
        {
            if (Validation())
            {
                _IShowCalendarDetail.IsShowInOut = isShowBtn;
                _IShowCalendarDetail.IsShowSendEmail = isShowSendEmail;
                if (CompanyConfig.HasHrmisSystem)
                {
                    _IShowCalendarDetail.LeaveRequestList =
                        _IEmployeeAttendanceStatisticsFacade.GetLeaveRequestListDetailByEmployee(_EmployeeID, _Date);
                    _IShowCalendarDetail.OutApplicationDetailList =
                        _IEmployeeAttendanceStatisticsFacade.GetOutApplicationDetailByEmployee(_EmployeeID, _Date);
                    _IShowCalendarDetail.OverWorkDetailList =
                        _IEmployeeAttendanceStatisticsFacade.GetOverWorkDetailByEmployee(_EmployeeID, _Date);
                    _IShowCalendarDetail.AttendanceBaseList =
                        _IEmployeeAttendanceStatisticsFacade.GetAttendanceBaseListDetailByEmployee(_EmployeeID, _Date);
                    _IShowCalendarDetail.AttendanceInAndOutRecordList = _IAttendanceInOutRecordFacade.GetSelfAttendanceInAndOutRecordByCondition(_EmployeeID, _Date,
                                                                                                 _Date.AddDays(1).AddMinutes(-1));
                       

                }
                if (CompanyConfig.HasCRMSystem && isShowCRM)
                {
                    //List<string> remindList = _ICalendarEventFacade.GetRemindDetailByEmployee(_EmployeeID, _Date);
                    //List<string> calendarEventList =
                    //    _ICalendarEventFacade.GetCalendarEventDetailByEmployee(_EmployeeID, _Date);
                    //_IShowCalendarDetail.RemindList = remindList;
                    //_IShowCalendarDetail.CalendarEventList = calendarEventList;

                    //_IShowCalendarDetail.IsShowRemind = (remindList.Count > 0);
                    //_IShowCalendarDetail.IsShowCalendar = (calendarEventList.Count > 0);
                }
                _IShowCalendarDetail.RefreshShow();
            }
        }
        //public void InitMultiView(object sender, EventArgs e)
        //{
        //    if (Validation())
        //    {
        //        _IShowCalendarDetail.LeaveRequestList = _IGetViewCalendar.GetLeaveRequestDetailByEmployee(_EmployeeID, _Date);
        //        _IShowCalendarDetail.ApplicationList = _IGetViewCalendar.GetApplicationDetailByEmployee(_EmployeeID, _Date);
        //        _IShowCalendarDetail.AttendanceBaseList = _IGetViewCalendar.GetAttendanceBaseDetailByEmployee(_EmployeeID, _Date);
        //    }
        //}
        public bool Validation()
        {
            _IShowCalendarDetail.ResultMessage = string.Empty;
            bool validation = true;

            if (!DateTime.TryParse(_IShowCalendarDetail.Date, out _Date))
            {
                _IShowCalendarDetail.ResultMessage = "请选择一个日期！";
                validation = false;
            }
            string employyID = _IShowCalendarDetail.EmployeeInfo.Split(';')[0];
            if (!int.TryParse(employyID, out _EmployeeID))
            {
                _IShowCalendarDetail.ResultMessage = "请选择一个员工！";
                validation = false;
            }
            return validation;
        }

        #region 测试用
        //public IMyAttendanceCalendar MockIGetViewCalendar
        //{
        //    set { _IMyAttendanceCalendar = value; }
        //}

        #endregion
    }
}
