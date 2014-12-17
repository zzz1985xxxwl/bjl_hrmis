//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DepartmentHistoryList.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-13
// 概述: 查看部门历史
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Pages;

namespace SEP.Performance.Pages
{
    public partial class DepartmentHistoryList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A301))
            {
                throw new ApplicationException("没有权限访问");
            }
            DepartmentHistoryListPresenter thePresenter = new DepartmentHistoryListPresenter(DepartmentHistoryListView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}
