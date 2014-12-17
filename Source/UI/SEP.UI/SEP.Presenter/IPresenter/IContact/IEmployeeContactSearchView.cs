//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEmployeeContactSearchView.cs
// 创建者: Emma
// 创建日期: 2008-12-02
// 概述: 查询员工通讯录界面
// ----------------------------------------------------------------
using System;

namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContactSearchView
    {
        string LinkManName{ get; set;}

        event EventHandler BtnSearchEvent;

    }
}