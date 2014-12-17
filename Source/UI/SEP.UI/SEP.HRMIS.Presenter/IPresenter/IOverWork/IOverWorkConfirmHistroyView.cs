//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOverWorkConfirmHistroyView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-17
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OverWork;

namespace SEP.HRMIS.Presenter.IPresenter.IOverWork
{
    public interface IOverWorkConfirmHistroyView
    {
        string EmployeeName { get;}

        bool? Adjust { get; }

        string FromDate { get; set;}

        string ToDate { get; set;}

        string DateMsg { get; set;}

        bool DisplaySearchCondition { set;}

        List<OverWork> OverWorkSource{ set;}

        event EventHandler BindOverWorkSource;
    }
}