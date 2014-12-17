//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetDelete.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 删除帐套
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AccountSetDelete : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A602))
            {
                throw new ApplicationException("没有权限访问");
            }
            DeleteAccountSetPresenter deleteAccountSetPresenter =
                new DeleteAccountSetPresenter(
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["AccountSetID"])),
                    AccountSetView1);
            deleteAccountSetPresenter.CancelEvent += ToAccountSetListPage;
            deleteAccountSetPresenter.ToAccountSetListPage += ToAccountSetListPage;
            deleteAccountSetPresenter.InitView(IsPostBack);
        }

        private void ToAccountSetListPage()
        {
            Response.Redirect("AccountSetList.aspx", false);
        }
    }
}