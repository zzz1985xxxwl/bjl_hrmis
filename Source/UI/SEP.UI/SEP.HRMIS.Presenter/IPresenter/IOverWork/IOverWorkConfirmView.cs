//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOverWorkConfirmView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-22
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OverWork;

namespace SEP.HRMIS.Presenter.IPresenter.IOverWork
{
    public interface IOverWorkConfirmView
    {

        List<OverWork> OverWorkSource { get;set;}

        event CommandEventHandler btnApproveCommand;

        event EventHandler BindOverWorkSource;

        event CommandEventHandler QuickPassEvent;
    }
}