//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOverWorkEditView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-14
// Resume:
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OverWork;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IOverWork
{
    public interface IOverWorkEditView
    {
        bool NotCalculate { get; set;}

        int ApplicationID { get; set; }

        string ResultMessage { get; set; }

        int EmployeeID { get; set; }

        string EmployeeName { get; set; }

        string Reason { get; set; }

        string ProjectName { get; set; }

        string ProjectNameMessage { get; set; }

        DateTime SubmitDate { get; set; }

        string ReasonMessage { get; set; }

        string OperationType { get; set; }

        string btnOKText { get; set; }

        string btnCancelText { get; set; }

        string TimeSpan { get; set; }

        string CostTime { get; set; }

        bool SetReadOnly { set; }

        List<OverWorkItem> ApplicationItemList { get; set; }

        List<Account> MailCC { get; set; }

        event EventHandler btnOKClick;

        event EventHandler btnSubmitClick;

        event DelegateID ApplicationItemForAddAtEvent;

        event DelegateID ApplicationItemForDeleteAtEvent;

        string Remind { get; set; }
    }
}