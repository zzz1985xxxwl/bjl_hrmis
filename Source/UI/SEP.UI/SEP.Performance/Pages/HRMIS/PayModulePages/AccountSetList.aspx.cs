//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetList.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 帐套列表
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AccountSetList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A602))
            {
                throw new ApplicationException("没有权限访问");
            }
            AccountSetListPresenter thePresenter = new AccountSetListPresenter(AccountSetListView1);
            thePresenter.btnAddClick += Add_Command;
            thePresenter.btnUpdateClick += Update_Command;
            thePresenter.btnDeleteClick += Delete_Command;
            thePresenter.btnDetailClick += Detail_Command;
            thePresenter.InitView(Page.IsPostBack);
        }

        private void Add_Command()
        {
            Response.Redirect("AccountSetAdd.aspx", false);
        }
        private void Update_Command(string id)
        {
            Response.Redirect("AccountSetUpdate.aspx?AccountSetID=" + SecurityUtil.DECEncrypt(id), false);

        }
        private void Delete_Command(string id)
        {
            Response.Redirect("AccountSetDelete.aspx?AccountSetID=" + SecurityUtil.DECEncrypt(id), false);
        }
        private void Detail_Command(string id)
        {
            Response.Redirect("AccountSetDetail.aspx?AccountSetID=" + SecurityUtil.DECEncrypt(id), false);
        }

    }
}