//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: VacationShowView.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-1
// 概述: 员工的年假信息显示控件，相当于detail界面，但不直接包含在aspx页中，现被包在VacationView中，然后对外显示
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance
{
    public partial class VacationShowView : UserControl
    {
        private Employee _Employee;
        private ShowVacationPresenter _ShowVacationPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            ManageVacationView1.AdjustRestVisible = false;
            _ShowVacationPresenter = new ShowVacationPresenter(ManageVacationView1);
            _ShowVacationPresenter.InitVacation(Employee, IsPostBack);
        }

        public Employee Employee
        {
            get
            {
                if (_Employee == null)
                {
                    _Employee = new Employee();
                    _Employee.Account.Id = 0;
                    _Employee.Account.Name = "";
                }
                return _Employee;
            }
            set { _Employee = value; }
        }
    }
}