//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SearchEmployeeInAndOutListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-29
// 概述: 考勤信息综合界面Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PresenterCore = SEP.Presenter.Core;
using SEP.IBll;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter
{
    public class SearchEmployeeInAndOutListPresenter
    {
        private readonly IPersonalInAndOutListView _View;
        //note colbert 2
        //private IAttendanceInOutRecordFacade _GetRecord = new AttendanceOutInRecord();

        //时间转换
        private DateTime _SearchFrom;
        private DateTime _SearchTo;
        private DateTime _OperatTimeFrom;
        private DateTime _OperatTimeTo;
        private readonly DateTime _From = Convert.ToDateTime("1900-01-01");
        private readonly DateTime _To = Convert.ToDateTime("2999-12-31");
        private readonly Account _LoginUser;
        public SearchEmployeeInAndOutListPresenter(IPersonalInAndOutListView listView, Account loginUser)
        {
            _View = listView;
            _LoginUser = loginUser;
            AttachViewEvent();
        }
        private void AttachViewEvent()
        {
            _View.BtnSearchEvent += DataBind;
        }
        public void InitView(bool isPostBack)
        {
            _View.SetButtonVisible = false;
            _View.TimeErrorMessage = string.Empty;
  
            if (!isPostBack)
            {
                List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
                _View.departmentSource = Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A504);

                _View.IOStatusSource = PersonalInAndOutUtilityPresenter.IoStatusSource();
                _View.OperateStatusSource = PersonalInAndOutUtilityPresenter.OperateStatusSource();

                _View.HoursSource = DutyClassUtility.Hours();
                _View.MinutesSource = DutyClassUtility.Minutes();
                _View.TimeFrom = "1900-1-1 0:00:00";
                _View.TimeTo = "2999-12-31 23:59:00";
                DataBind();
            }
        }

        public void DataBind()
        {
            if (ValidateTimeFrom() && ValidateTimeTo() && ValidateOperateTimeFrom() && ValidateOperateTimeTo())
            {
                _View.InAndOutRecords =
                    InstanceFactory.AttendanceInOutRecordFacade().GetEmployeeInAndOutRecordByCondition(-1,
                                                                                                     _View.EmployeeName,
                                                                                                     _View.Department,
                                                                                                     string.Empty,
                                                                                                     _SearchFrom,
                                                                                                     _SearchTo,
                                                                                                     AttendanceInAndOutRecord
                                                                                                         .
                                                                                                         GetInOutStatusByInOutName
                                                                                                         (
                                                                                                         _View.
                                                                                                             IOStatusId),
                                                                                                     AttendanceInAndOutRecord
                                                                                                         .
                                                                                                         GetOutInRecordOperateStatus
                                                                                                         (_View.
                                                                                                              OperateStatusId),
                                                                                                     _OperatTimeFrom,
                                                                                                     _OperatTimeTo, _LoginUser);
            }
        }

        #region 验证

        private bool ValidateTimeFrom()
        {
            if (string.IsNullOrEmpty(_View.TimeFrom))
            {
                _SearchFrom = _From;
                return true;
            }
            if (!DateTime.TryParse(_View.TimeFrom, out _SearchFrom))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }
            return true;
        }

        private bool ValidateTimeTo()
        {
            if (string.IsNullOrEmpty(_View.TimeTo))
            {
                _SearchTo = _To;
                return true;
            }
            if (!DateTime.TryParse(_View.TimeTo, out _SearchTo))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }
            return true; 
        }

        private bool ValidateOperateTimeFrom()
        {
            if (string.IsNullOrEmpty(_View.OperatTime))
            {
                _OperatTimeFrom = _From;
                return true;
            }
            if (!DateTime.TryParse(_View.OperatTime, out _OperatTimeFrom))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }
            return true;
        }

        private bool ValidateOperateTimeTo()
        {
            if (string.IsNullOrEmpty(_View.OperatTo))
            {
                _OperatTimeTo = _To;
                return true;
            }
            if (!DateTime.TryParse(_View.OperatTo, out _OperatTimeTo))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }
            return true;
        }

        #endregion

        #region use for tests

        //note colbert 2
        //public IAttendanceOutInRecord GetRecord
        //{
        //    set { _GetRecord = value; }
        //}

        //public IGetDepartment SetGetDepartment
        //{
        //    set
        //    {
        //        _Department = value;
        //    }
        //}

        #endregion
    }
}
