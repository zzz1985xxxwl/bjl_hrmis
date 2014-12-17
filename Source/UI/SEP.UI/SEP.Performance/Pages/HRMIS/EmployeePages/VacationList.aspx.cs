//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: VacationList.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 增加VacationList
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages
{
    public partial class VacationList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A403))
            {
                throw new ApplicationException("没有权限访问");
            }
            new VacationListPresenter(VacationListView, IsPostBack, LoginUser);
        }
    }
}
