//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOutApplicationEditView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-14
// Resume:
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IOutApplication
{
    public interface IOutApplicationEditView
    {
        bool NotCalculate{ get; set;}

        int ApplicationID { get; set; }

        string ResultMessage { get; set; }

        int EmployeeID { get; set; }

        string EmployeeName { get; set; }

        string Reason { get; set; }

        string OutLocation { get; set; }

        OutType OutType { get; set; }

        string OutLocationMessage { get; set; }

        DateTime SubmitDate { get; set; }

        string ReasonMessage { get; set; }

        string OperationType { get; set; }

        string btnOKText { get; set; }

        string btnCancelText { get; set; }

        string TimeSpan { get; set; }

        string CostTime { get; set; }

        bool SetReadOnly { set; }

        List<OutApplicationItem> ApplicationItemList { get; set; }

        List<Account> MailCC { get; set; }

        event EventHandler btnOKClick;

        event EventHandler btnSubmitClick;

        event DelegateID ApplicationItemForAddAtEvent;

        event DelegateID ApplicationItemForDeleteAtEvent;

        event DelegateNoParameter OutTypeSelectChange;
        string Remind { get; set; }
    }
}