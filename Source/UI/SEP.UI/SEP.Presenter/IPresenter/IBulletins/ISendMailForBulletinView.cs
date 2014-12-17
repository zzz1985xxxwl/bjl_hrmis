//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISendMailForBulletinView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-17
// 概述: 增加ISendMailForBulletinView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.Presenter.IPresenter.IBulletins
{
    public interface ISendMailForBulletinView
    {
        int BulletinID { get; set;}

        int EmployeeID { get; set; }

        string EmployeeNameForRight { get; set; }

        string EmployeeName { get; set; }

        int DepartmentID { get; set; }

        int PositionID { get; set;}

        string MessageFromBll { get; set;}

        string BulletinTitle { get; set;}

        List<Account> EmployeeRight { get; set; }

        List<Account> EmployeeLeft { get; set; }

        List<Department> DepartmentList { get;set; }

        List<Position> PositionList { get;set; }

        event EventHandler SearchEmployeeEvent;

        event EventHandler SendMailEvent;

        event EventHandler ToRightEvent;

        event EventHandler ToLeftEvent;

        event EventHandler InitView;
    }
}