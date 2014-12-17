//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetDetail.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 帐套详情
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AccountSetDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A602))
            {
                throw new ApplicationException("没有权限访问");
            }
            DetailAccountSetPresenter detailAccountSetPresenter =
                new DetailAccountSetPresenter(
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["AccountSetID"])),
                    AccountSetView1);
            detailAccountSetPresenter.CancelEvent += ToAccountSetListPage;
            detailAccountSetPresenter.InitView(IsPostBack);
        }

        private void ToAccountSetListPage()
        {
            Response.Redirect("AccountSetList.aspx", false);
        }
    }
}