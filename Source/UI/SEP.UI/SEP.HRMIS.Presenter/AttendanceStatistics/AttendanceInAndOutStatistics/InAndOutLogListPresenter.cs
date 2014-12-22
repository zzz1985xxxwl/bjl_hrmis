//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InAndOutLogListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-23
// 概述: 日志信息列表Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public class InAndOutLogListPresenter
    {
        private readonly IInAndOutLogListView _View;

        //note colbert 2
        //private IGetInAndOutRecordLog _GetLog = new GetInAndOutRecordLog();
        //private IGetDepartment _Department = new GetDepartment();

        //时间转换
        private DateTime _SearchFrom;
        private DateTime _SearchTo;
        private DateTime _OperatTimeFrom;
        private DateTime _OperatTimeTo;
        private readonly DateTime _From = Convert.ToDateTime("1900-01-01");
        private readonly DateTime _To = Convert.ToDateTime("2999-12-01");
        private readonly Account _LoginUser;
        public InAndOutLogListPresenter(IInAndOutLogListView listView, Account loginUser)
        {
            _View = listView;
            _LoginUser = loginUser;
            _View.BtnSearchEvent += DataBind;
        }

        public void Initialize(bool isPostBack)
        {
            _View.TimeErrorMessage = String.Empty;
            _View.ErrorMessage = String.Empty;

            if (isPostBack)
                return;

            List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
            _View.departmentSource =
                Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A508);

            //_View.OperateStatusSource = PersonalInAndOutUtilityPresenter.OperateStatusSource();
            DataBind();
        }

        private void DataBind()
        {
            if (!ValidateDateTime())
            {
                return;
            }

            try
            {
                _View.InAndOutLogs =
                    InstanceFactory.AttendanceInOutRecordFacade().GetInAndOutLogByCondition(_View.EmployeeName,
                                                                                          _View.DepartmentId,
                                                                                          _OperatTimeFrom,
                                                                                          _OperatTimeTo,
                                                                                          _View.operatorName,
                                                                                          _SearchFrom, _SearchTo, _LoginUser);
            }
            catch (Exception e)
            {
                _View.ErrorMessage = e.Message;
            }
        }

        #region 验证

        private bool ValidateDateTime()
        {
            if (string.IsNullOrEmpty(_View.TimeFrom))
            {
                _SearchFrom = _From;
                //return true;
            }
            else if (!DateTime.TryParse(_View.TimeFrom, out _SearchFrom))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }

            if (string.IsNullOrEmpty(_View.TimeTo))
            {
                _SearchTo = _To;
                //return true;
            }
            else if (!DateTime.TryParse(_View.TimeTo, out _SearchTo))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }

            if (string.IsNullOrEmpty(_View.OperatTime))
            {
                _OperatTimeFrom = _From;
                //return true;
            }
            else if (!DateTime.TryParse(_View.OperatTime, out _OperatTimeFrom))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }

            if (string.IsNullOrEmpty(_View.OperatTo))
            {
                _OperatTimeTo = _To;
                //return true;
            }
            else if (!DateTime.TryParse(_View.OperatTo, out _OperatTimeTo))
            {
                _View.TimeErrorMessage = "查询时间设置错误";
                return false;
            }

            return true;
        }
        #endregion

        #region use for tests
        //note colbert 2
        //public IGetInAndOutRecordLog  GetLog
        //{
        //    set { _GetLog = value; }
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
