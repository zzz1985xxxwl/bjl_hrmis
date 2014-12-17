//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: ILoginView.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 登录
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;

namespace SEP.Presenter.IPresenter.IAccounts
{
    public interface ILoginView
    {
        string ValidateLoginName { get; set; }

        string ValidatePassword { get; set; }

        string LoginName { get; set; }

        string Password { get; set; }

        string Message { get; set; }

        int UsbKeyCount { get; }
        Account LoginUser { set;}

        string UsbKey { get; set; }
        event EventHandler btnOKClick;
    }
}
