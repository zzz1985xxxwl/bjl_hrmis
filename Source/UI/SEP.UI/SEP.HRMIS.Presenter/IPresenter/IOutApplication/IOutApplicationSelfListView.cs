//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IApplicationSelfListView.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IOutApplication
{
    public interface IOutApplicationSelfListView
    {

        List<OutApplication> OutApplicationSource{ get; set;}

        event DelegateNoParameter BindOutApplicationSource;

        event DelegateID btnDeleteClick;
    }
}