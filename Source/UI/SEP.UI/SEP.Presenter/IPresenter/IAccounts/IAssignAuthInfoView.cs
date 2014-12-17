//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IAssignAuthInfoView.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-17
// Resume: 
// ----------------------------------------------------------------

namespace SEP.Presenter.IPresenter.IAccounts
{
    public interface IAssignAuthInfoView
    {
        IAssignAuthView AssignAuthView { get; set;}

        IAssignAuthDepartmentTree DepartmentTreeView { get; set;}

        bool AssignAuthDepartmentTreeVisible { get; set;}
    }
}