//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOperationView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-23
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Presenter.IPresenter.IOverWork
{
    public interface IOverWorkOperationView
    {
        int EmployeeID { get; set;}

        string EmployeeName { get; set;}

        string OverWorkFlowID { get; set;}

        int OverWorkID { get; set;}

        string Remark { get; set;}

        string OperationType { get; set;}

        string Status { get; set;}

        Dictionary<string, string> StatusSource { get; set;}

        string ResultMessage { get; set;}

        string RemarkMessage { get; set;}

        event EventHandler btnOKClick;

        bool SetFormReadOnly { get; set;}

        bool SetStatusReadOnly { get; set;}

        string btnCancelOnClientClick { set;}

        event EventHandler UpdateListWindow;
    }
}