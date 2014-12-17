//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AttendanceErrorListPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-10-21
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.IPresenter.ISystemError;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter.SystemErrors
{
    /// <summary>
    /// </summary>
    public class AttendanceErrorListPresenter
    {
        private readonly IAttendanceErrorListPresenter _View;
        private readonly Account _LoginUser;
        private readonly ISystemErrorFacade _ISystemErrorFacade = InstanceFactory.CreateSystemErrorFacade();
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private DateTime dtFromDate;
        private DateTime dtToDate;

        public AttendanceErrorListPresenter(IAttendanceErrorListPresenter view, Account loginUser, bool isPostBack)
        {
            _View = view;
            _LoginUser = loginUser;
            AttachEvent();
            Init(isPostBack);
        }

        private void AttachEvent()
        {
            _View.SearchEvent += SearchAttendanceError;
        }

        private void Init(bool isPostBack)
        {
            _View.ScopeMsg = string.Empty;
            if (!isPostBack)
            {
                _View.FromDate = new HrmisUtility().CurrenMonthStartTime().ToShortDateString(); //月头
                _View.ToDate = new HrmisUtility().CurrenMonthEndTime().ToShortDateString(); //月末
                BindDepartment();
                SearchAttendanceError();
            }
        }

        public static List<Department> GetDepartment(Account loginUser)
        {
            return
                Tools.RemoteUnAuthDeparetment(BllInstance.DepartmentBllInstance.GetAllDepartment(), AuthType.HRMIS, loginUser,
                                              HrmisPowers.A506);
        }

        public void BindDepartment()
        {
            List<Department> deptList =
                Tools.RemoteUnAuthDeparetment(_IDepartmentBll.GetAllDepartment(), AuthType.HRMIS, _LoginUser,
                                              HrmisPowers.A506);
            _View.DepartmentSource = deptList;
        }

        private void SearchAttendanceError()
        {
            if (Valid())
            {
                _View.SystemErrors =
                    _ISystemErrorFacade.GetAttendanceError(_View.EmployeeName, _View.DepartmentID, dtFromDate, dtToDate,
                                                           _LoginUser, HrmisPowers.A506);
            }
        }


        private bool Valid()
        {
            bool ret = true;
            if (String.IsNullOrEmpty(_View.FromDate) || String.IsNullOrEmpty(_View.ToDate))
            {
                _View.ScopeMsg = "时间不可为空";
                ret = false;
            }
            else
            {
                if (
                    !(DateTime.TryParse(_View.FromDate, out dtFromDate) && DateTime.TryParse(_View.ToDate, out dtToDate)))
                {
                    _View.ScopeMsg = "时间格式输入不正确";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtFromDate, dtToDate) > 0)
                    {
                        _View.ScopeMsg = "开始时间不可晚于结束时间";
                        ret = false;
                    }
                }
            }
            return ret;
        }
    }
}