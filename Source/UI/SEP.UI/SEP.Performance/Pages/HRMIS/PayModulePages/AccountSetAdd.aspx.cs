//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AccountSetAdd.cs
// ������: wang.shali
// ��������: 2008-12
// ����: ��������
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AccountSetAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A602))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            } 
            CreateAccountSetPresenter createAccountSetPresenter = new CreateAccountSetPresenter(AccountSetView1);
            createAccountSetPresenter.CancelEvent += ToAccountSetListPage;
            createAccountSetPresenter.ToAccountSetListPage += ToAccountSetListPage;
            createAccountSetPresenter.InitView(IsPostBack);
        }

        private void ToAccountSetListPage()
        {
            Response.Redirect("AccountSetList.aspx", false);
        }
    }
}