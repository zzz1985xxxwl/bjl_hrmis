//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayAttendancePresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-09-02
// 概述: 日考勤
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PresenterCore = SEP.Presenter.Core;
namespace SEP.HRMIS.Presenter.AttendanceStatistics
{
    public class DayAttendancePresenter
    {
        public IDayAttendance _IDayAttendance;
        public IEmployeeAttendanceStatisticsFacade _IEmployeeAttendanceStatisticsFacade
            = InstanceFactory.CreateEmployeeAttendanceStatisticsFacade();

        private DateTime _FromDate;
        private DateTime _ToDate;
        private int _DepartmentID;
        private readonly Account _LoginUser;
        private EmployeeWithAttendanceList _EmployeeWithAttendanceList;
        public DayAttendancePresenter(IDayAttendance view, Account loginUser)
        {
            _IDayAttendance = view;
            _LoginUser = loginUser;
        }
        private void OperationAndSplitWeek()
        {
            if (Validation())
            {
                if (_DepartmentID==0)
                {
                    _DepartmentID = -1;
                }
                #region 找到第一周的开始，最后一周的结束
                //把星期一当作一周的开始
                //第一周的开始
                if (_FromDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    _FromDate = _FromDate.AddDays(-6);
                }
                else
                {
                    _FromDate = _FromDate.AddDays(1 - (int)_FromDate.DayOfWeek);
                }
                //最后一周的结束
                if (_ToDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    _ToDate = _ToDate.AddDays(7-(int)_ToDate.DayOfWeek);
                }
                #endregion
                //得到一段时间内所有考勤信息
                List<Employee> employeeList = _IEmployeeAttendanceStatisticsFacade.GetAllEmployeeAttendanceByCondition(
                    _IDayAttendance.EmployeeName, _DepartmentID,_IDayAttendance.GradesId, _FromDate, _ToDate, _LoginUser, HrmisPowers.A506);
                _EmployeeWithAttendanceList = new EmployeeWithAttendanceList(employeeList, _FromDate, _ToDate);
                //把这段时间拆分为周,并赋值
                _EmployeeWithAttendanceList.SplitWeek();
                _IDayAttendance.DayAttendanceWeek1List = _EmployeeWithAttendanceList.DayAttendanceWeek1List;
                _IDayAttendance.DayAttendanceWeek2List = _EmployeeWithAttendanceList.DayAttendanceWeek2List;
                _IDayAttendance.DayAttendanceWeek3List = _EmployeeWithAttendanceList.DayAttendanceWeek3List;
                _IDayAttendance.DayAttendanceWeek4List = _EmployeeWithAttendanceList.DayAttendanceWeek4List;
                _IDayAttendance.DayAttendanceWeek5List = _EmployeeWithAttendanceList.DayAttendanceWeek5List;
                _IDayAttendance.DayAttendanceWeek6List = _EmployeeWithAttendanceList.DayAttendanceWeek6List;
                _IDayAttendance.Week1List = _EmployeeWithAttendanceList.Week1List;
                _IDayAttendance.Week2List = _EmployeeWithAttendanceList.Week2List;
                _IDayAttendance.Week3List = _EmployeeWithAttendanceList.Week3List;
                _IDayAttendance.Week4List = _EmployeeWithAttendanceList.Week4List;
                _IDayAttendance.Week5List = _EmployeeWithAttendanceList.Week5List;
                _IDayAttendance.Week6List = _EmployeeWithAttendanceList.Week6List;

                _IDayAttendance.ResultMessage =
                        "<span class='font14b'>共有 </span>"
                        + "<span class='fontred'>" + _EmployeeWithAttendanceList.DayAttendanceWeek1List.Count + "</span>"
                        + "<span class='font14b'> 条统计记录</span>";
            }
        }
        public void SearchDayAttendance(object sender, EventArgs e)
        {
            OperationAndSplitWeek();
        }

        public bool Validation()
        {
            _IDayAttendance.ResultMessage = string.Empty;
            bool validation = true;

            if (!DateTime.TryParse(_IDayAttendance.FromDate, out _FromDate) ||
                !DateTime.TryParse(_IDayAttendance.ToDate, out _ToDate))
            {
                _IDayAttendance.ResultMessage = "时间格式不正确！";
                validation = false;
            }
            if (!int.TryParse(_IDayAttendance.DepartmentId, out _DepartmentID))
            {
                _IDayAttendance.ResultMessage = "部门ID应为整数！";
                validation = false;
            }
            return validation;
        }

        #region 测试用
        //public IEmployeeAttendanceStatistics MockIEmployeeAttendanceStatistics
        //{
        //    set { _IEmployeeAttendanceStatistics = value; }
        //}

        //public IGetDepartment SetGetDepartment
        //{
        //    set
        //    {
        //        _Department = value;
        //    }
        //}
        #endregion

        public void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
                _IDayAttendance.DepartmentSource = Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A506);
                _IDayAttendance.GradesSource = GradesType.GetAll();
                _IDayAttendance.DepartmentId = "-1";
                _IDayAttendance.FromDate = DateTime.Now.AddDays(1 - DateTime.Now.Day).ToShortDateString();
                _IDayAttendance.ToDate = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1).ToShortDateString();
                OperationAndSplitWeek();
            }
        }
    }
}
