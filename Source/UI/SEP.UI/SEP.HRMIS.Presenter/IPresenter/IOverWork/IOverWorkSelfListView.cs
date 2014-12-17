//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IApplicationSelfListView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.OverWork;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IOverWork
{
    public interface IOverWorkSelfListView
    {

        List<OverWork> OverWorkSource{ get; set;}

        event DelegateNoParameter BindOverWorkSource;

        event DelegateID btnDeleteClick;
    }
}