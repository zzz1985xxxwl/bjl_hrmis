//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ICancelOutApplicationItemView.cs
// Creater:  Xue.wenlong
// Date:  2009-05-06
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.HRMIS.Presenter.IPresenter.IOutApplication
{
    public interface ICancelOutApplicationItemView
    {
        int ApplicationID { get; set; }

        string ResultMessage { get; set; }

        int EmployeeID { get; set; }

        string EmployeeName { get; set; }

        string Reason { get; set; }

        string OutLocation { get; set; }

        string TimeSpan { get; set; }

        string CostTime { get; set; }

        OutType OutType { get; set; }

        OperationType OperationType { get; set; }

        List<OutApplicationItem> ApplicationItemList { get; set; }

        Dictionary<string, string> ApproveStatusSource { set; }

        event EventHandler btnOKClick;
    }
}