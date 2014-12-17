//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOutApplicationConfirmView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-22
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OutApplication;

namespace SEP.HRMIS.Presenter.IPresenter.IOutApplication
{
    public interface IOutApplicationConfirmView
    {

        List<OutApplication> OutApplicationSource { get;set;}

        event CommandEventHandler btnApproveCommand;

        event EventHandler BindOutApplicationSource;

        event CommandEventHandler QuickPassEvent;
    }
}