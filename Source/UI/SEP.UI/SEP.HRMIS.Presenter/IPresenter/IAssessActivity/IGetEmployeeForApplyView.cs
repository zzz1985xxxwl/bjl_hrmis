//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IGetEmployeeForApplyView.cs
// 创建者: wang.shali
// 创建日期: 2008-06-25
// 概述: 人事为员工申请考评
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IGetEmployeeForApplyView
    {
        string RedirectPage { set; }
        bool IsSearch { set; }
        string EmployeeName { get; }
        List<Account> Employees { get; set;}
        event EventHandler BindAssessActivity;
        List<Position> PositionSource { set;}
        List<Department> DepartmentSource { set;}
        int PositionId { get;}
        int DepartmentId { get;}
        bool RecursionDepartment { get; }
        EmployeeTypeEnum EmployeeType { get;set;}
        Dictionary<string, string> EmployeeTypeSource { set;}

    }
}
