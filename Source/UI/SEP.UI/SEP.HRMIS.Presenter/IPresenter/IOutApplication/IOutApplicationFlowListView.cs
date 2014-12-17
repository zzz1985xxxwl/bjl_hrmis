//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOutApplicationFlowListView.cs
// Creater:  Xue.wenlong
// Date:  2009-05-08
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IOutApplication
{
    public interface IOutApplicationFlowListView
    {
        List<OutApplicationFlow> OutApplicationFlowSource { set; }
        event DelegateNoParameter BindOutApplicationFlowSource;
    }
}