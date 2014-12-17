//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceSearchPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-08-12
// 概述: 缺勤查询界面Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance;
using SEP.HRMIS.IFacede;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeAttendances
{
    public class AttendanceSearchPresenter:PresenterCore.BasePresenter
    {
        private readonly IAttendaceSearchView _View;
        //private readonly GetBadAttendance _Attendance = new GetBadAttendance();
        private readonly IEmployeeAttendanceFacade _AttendanceBll = InstanceFactory.CreateEmployeeAttendanceFacade();
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;

        private DateTime _DayFrom;
        private DateTime _DayTo;

        public AttendanceSearchPresenter(IAttendaceSearchView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
        }
        public override void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                _View.AttendanceTypes = GetAttendanceTypes();
                _View.GradesSource = GradesType.GetAll();
                _View.SelectedType = string.Empty;
                SearchEvent();
            }
        }

        private void AttachViewEvent()
        {
            _View.OnSearch += SearchEvent;
        }

        public void SearchEvent()
        {
            if (ValidateSearchDay())
            {
                try
                {
                    List<AttendanceBase> attendanceBaseList = _AttendanceBll.GetAttendanceByCondition(_View.EmployeeName,_View.GradesId, _DayFrom, _DayTo, _View.SelectedType, LoginUser);

                    foreach (AttendanceBase attendanceBase in attendanceBaseList)
                    {
                        Account account = _IAccountBll.GetAccountById(attendanceBase.EmployeeId);
                        if (account == null)
                        {
                            continue;
                        }
                        attendanceBase.EmployeeName = account.Name;
                    }
                    _View.attendances = attendanceBaseList;
                }
                catch (ApplicationException ex)
                {
                    _View.Message = ex.Message;
                }
            }
        }

        private List<string> GetAttendanceTypes()
        {
            List<string> types = new List<string>();
            types.Add(string.Empty);
            types.Add(EmployeeAttendanceUtilitys._Absent);
            types.Add(EmployeeAttendanceUtilitys._EarlyLeave);
            types.Add(EmployeeAttendanceUtilitys._Later);
            return types;
        }

        #region 验证查询界面输入
        public bool ValidateSearchDay()
        {
            return VaildateDayFrom() && ValidateDayTo();
        }

        private bool VaildateDayFrom()
        {
            if (string.IsNullOrEmpty(_View.TheDayFrom))
            {
                _DayFrom = EmployeeAttendanceUtilitys._StratTime;
                return true;
            }
            if (!DateTime.TryParse(_View.TheDayFrom, out _DayFrom))
            {
                _View.Message = EmployeeAttendanceUtilitys._ErrorTheDay;
                return false;
            }
            return true;
        }

        private bool ValidateDayTo()
        {
            if (string.IsNullOrEmpty(_View.TheDayTo))
            {
                _DayTo = EmployeeAttendanceUtilitys._EndTime;
                return true;
            }
            if (!DateTime.TryParse(_View.TheDayTo, out _DayTo))
            {
                _View.Message = EmployeeAttendanceUtilitys._ErrorTheDay;
                return false;
            }
            return true;
        }
        #endregion

       
    }
}
