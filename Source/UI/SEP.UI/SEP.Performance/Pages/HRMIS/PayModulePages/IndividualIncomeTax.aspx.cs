//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IndividualIncomeTax.cs
// 创建者: 薛文龙
// 创建日期: 2008-12-29
// 概述: 设置税制界面
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class IndividualIncomeTax : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A603))
            {
                throw new ApplicationException("没有权限访问");
            }
        }
    }
}