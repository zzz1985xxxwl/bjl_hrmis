//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ICancelOverWorkItemView.cs
// Creater:  Xue.wenlong
// Date:  2009-05-06
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.HRMIS.Presenter.IPresenter.IOverWork
{
    public interface ICancelOverWorkItemView
    {
        int ApplicationID { get; set; }

        string ResultMessage { get; set; }

        int EmployeeID { get; set; }

        string EmployeeName { get; set; }

        string Reason { get; set; }

        string OutLocation { get; set; }

        string TimeSpan { get; set; }

        string CostTime { get; set; }

        OperationType OperationType { get; set; }

        List<OverWorkItem> ApplicationItemList { get; set; }

        Dictionary<string, string> ApproveStatusSource { set; }

        event EventHandler btnOKClick;

        string SurplusAdjustRest { set;}
    }
}