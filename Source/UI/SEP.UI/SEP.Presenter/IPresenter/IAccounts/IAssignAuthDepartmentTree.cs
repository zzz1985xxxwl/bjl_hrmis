//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IAssignAuthDepartmentTree.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-17
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.Presenter.IPresenter.IAccounts
{
    public interface IAssignAuthDepartmentTree
    {
        string BackAccountsID { get; set;}

        string AuthID { get; set;}

        List<Department> DepartmentList { get; set;}

        event Core.DelegateNoParameter ShowView;

        event Core.DelegateNoParameter SaveClick;

        bool ActionSuccess { get; set; }

        List<Auth> AuthSource { get; set;}
    }
}