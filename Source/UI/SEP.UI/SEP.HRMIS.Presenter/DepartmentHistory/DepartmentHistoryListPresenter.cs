//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DepartmentHistoryListPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-13
// 概述: 增加DepartmentHistoryListPresenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter
{
    public class DepartmentHistoryListPresenter
    {
        private readonly IDepartmentHistoryListView _ItsView;
        private IDepartmentHistoryFacade _IDepartmentHistoryFacade = InstanceFactory.CreateDepartmentHistoryFacade();
        private IEmployeeHistoryFacade _IEmployeeHistoryFacade = InstanceFactory.CreateEmployeeHistoryFacade();
        private DateTime _SearchTime;
        private List<Department> DepartmentOrder;
        public DepartmentHistoryListPresenter(IDepartmentHistoryListView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                _ItsView.Title = "组织架构";
                DepartmentDataBind();
            }
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += DepartmentDataBind;
        }

        public void DepartmentDataBind()
        {
            try
            {
                _ItsView.Message = string.Empty;
                if (ValidateTime())
                {
                    DepartmentOrder = new List<Department>();
                    if (DateTime.Compare(_SearchTime, DateTime.Now) > 0)
                    {
                        _SearchTime = DateTime.Now;
                    }
                    List<Department> itsSource = _IDepartmentHistoryFacade.GetDepartmentTreeStructByDateTime(_SearchTime);
                    Order(itsSource, "");
                    List<Employee> EmployeesSource = _IEmployeeHistoryFacade.GetOnDutyEmployeeBasicInfoByDateTime(_SearchTime);
                    List<Account> AccountSource = new List<Account>();
                    foreach (Employee employees in EmployeesSource)
                    {
                        AccountSource.Add(employees.Account);
                    }
                    foreach (Department department in DepartmentOrder)
                    {
                        _DepartmentID = department.DepartmentID;
                        department.Members = AccountSource.FindAll(FindAccount);
                    }
                    _ItsView.Departments = DepartmentOrder;
                }
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
        private int _DepartmentID;
        private bool FindAccount(Account account)
        {
            if (account.Dept.Id == _DepartmentID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Order(IEnumerable<Department> departmentList, string indexfromroot)
        {
            if (departmentList != null)
            {
                int i = 1;
                foreach (Department department in departmentList)
                {
                    department.IndexFromRoot = indexfromroot + "_" + i++;
                    DepartmentOrder.Add(department);
                    if (department.ChildDept.Count > 0)
                    {
                        Order(department.ChildDept, department.IndexFromRoot);
                    }
                }
            }
        }

        public bool ValidateTime()
        {
            if (string.IsNullOrEmpty(_ItsView.SearchTime))
            {
                _SearchTime = DateTime.Now;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.SearchTime + " 23:59:59", out _SearchTime))
            {
                _ItsView.Message = "查询时间设置错误";
                return false;
            }
            return true;
        }

    }
}

