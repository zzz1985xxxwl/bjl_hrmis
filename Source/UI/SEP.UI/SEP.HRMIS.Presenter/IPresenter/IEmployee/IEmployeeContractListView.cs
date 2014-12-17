//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEmployeeContractListView.cs
// 创建者: 刘丹
// 创建日期: 2008-06-20
// 概述: 员工合同list界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeContractListView
    {
        string ResultMessage { set;}
        List<Contract> EmployeeContract { set;}
        bool ButtonEnable { set;}
        string EmployeeName { set;}
        bool setGirdViewConlumn { set;}
    }
}
