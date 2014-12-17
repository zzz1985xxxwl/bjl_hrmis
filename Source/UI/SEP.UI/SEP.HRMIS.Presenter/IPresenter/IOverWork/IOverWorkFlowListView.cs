//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOverWorkFlowListView.cs
// Creater:  Xue.wenlong
// Date:  2009-05-08
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.OverWork;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IOverWork
{
    public interface IOverWorkFlowListView
    {
        List<OverWorkFlow> OverWorkFlowSource { set; }
        event DelegateNoParameter BindOverWorkFlowSource;
    }
}