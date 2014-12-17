//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOutApplicationConfirmHistroyView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-17
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;

namespace SEP.HRMIS.Presenter.IPresenter.IOutApplication
{
    public interface IOutApplicationConfirmHistroyView
    {
        string EmployeeName { get;}

        string FromDate { get; set;}

        string ToDate { get; set;}

        string DateMsg { get; set;}

        bool DisplaySearchCondition { set;}

        List<OutApplication> OutApplicationSource{ set;}

        event EventHandler BindOutApplicationSource;
    }
}