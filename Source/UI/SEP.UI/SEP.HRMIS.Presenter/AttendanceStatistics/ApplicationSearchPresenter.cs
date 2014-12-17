//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ApplicationSearchPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2009-6-1
// 概述: 
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter.AttendanceStatistics
{
    public class ApplicationSearchPresenter
    {
        private readonly IApplicationSearchView _ItsView;
        public IEmployeeAttendanceFacade _IEmployeeAttendanceFacade
            = InstanceFactory.CreateEmployeeAttendanceFacade();

        private readonly Account _LoginUser;
        public ApplicationSearchPresenter(IApplicationSearchView itsView, Account loginAccount)
        {
            _ItsView = itsView;
            _LoginUser = loginAccount;
            AttachViewEvent();
        }

        public void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                GetBaseData();
                ApplicationSearchDataBind();
            }
        }

        public void GetBaseData()
        {

            List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
            _ItsView.DepartmentList =
                Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A509);
            _ItsView.GradesSource = GradesType.GetAll();
            _ItsView.ApplicationTypeEnumSourse = GetApplicationTypeEnum();
            _ItsView.RequestStatusSourse = RequestStatus.AllRequestStatuss;
            _ItsView.SearchFrom = DateTime.Now.ToShortDateString();
            _ItsView.SearchTo = DateTime.Now.ToShortDateString();
        }

        public static List<ApplicationTypeEnum> GetApplicationTypeEnum()
        {
            List<ApplicationTypeEnum> applicationTypeEnum = new List<ApplicationTypeEnum>();
            applicationTypeEnum.Add(ApplicationTypeEnum.All);
            applicationTypeEnum.Add(ApplicationTypeEnum.OverTime);
            applicationTypeEnum.Add(ApplicationTypeEnum.LeaveRequest);
            applicationTypeEnum.Add(ApplicationTypeEnum.OutCityOut);
            applicationTypeEnum.Add(ApplicationTypeEnum.InCityOut);
            applicationTypeEnum.Add(ApplicationTypeEnum.TrainOut);
            return applicationTypeEnum;
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += ApplicationSearchDataBind;
        }

        private int _DepartmentID;
        private static DateTime _SearchFrom;
        private static DateTime _SearchTo;
        private ApplicationTypeEnum _ApplicationType;
        private RequestStatus _ApplicationStatus;

        public void ApplicationSearchDataBind()
        {
            if (Vaildate())
            {
                List<Request> itsSource = _IEmployeeAttendanceFacade.
                    GetRequestRecordByCondition(_ItsView.EmployeeName, _DepartmentID,_ItsView.GradesId,
                    _SearchFrom, _SearchTo, _ApplicationType, _ApplicationStatus, _LoginUser);
                _ItsView.RequestList = itsSource;
            }
        }

        public bool Vaildate()
        {
            _ItsView.ErrorMessage = string.Empty;
            _ItsView.ErrorValidateTime = string.Empty;
            if (!int.TryParse(_ItsView.DepartmentID, out _DepartmentID))
            {
                _ItsView.ErrorMessage = "部门ID必须为整数!";
                return false;
            }
            if (string.IsNullOrEmpty(_ItsView.SearchFrom))
            {
                _SearchFrom = Convert.ToDateTime("1900-1-1");
            }
            else if (!DateTime.TryParse(_ItsView.SearchFrom, out _SearchFrom))
            {
                _ItsView.ErrorValidateTime = "查询时间格式不正确！";
                return false;
            }
            if (string.IsNullOrEmpty(_ItsView.SearchTo))
            {
                _SearchTo = Convert.ToDateTime("2900-12-31");
            }
            else if (!DateTime.TryParse(_ItsView.SearchTo, out _SearchTo))
            {
                _ItsView.ErrorValidateTime = "查询时间格式不正确！";
                return false;
            }
            int applicationTypeID;
            int statusID;
            if (!int.TryParse(_ItsView.ApplicationType, out applicationTypeID))
            {
                _ItsView.ErrorMessage = "申请类型设置不正确！";
                return false;
            }
            if (!int.TryParse(_ItsView.Status, out statusID))
            {
                _ItsView.ErrorMessage = "申请状态设置不正确!";
                return false;
            }
            _ApplicationType = (ApplicationTypeEnum)applicationTypeID;
            _ApplicationStatus = RequestStatus.FindRequestStatus(statusID);
            return true;
        }
    }
}
