//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AccountSetUpdate.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �޸�����
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AccountSetUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A602))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            }
            UpdateAccountSetPresenter updateAccountSetPresenter =
                new UpdateAccountSetPresenter(
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["AccountSetID"])),
                    AccountSetView1);
            updateAccountSetPresenter.CancelEvent += ToAccountSetListPage;
            updateAccountSetPresenter.ToAccountSetListPage += ToAccountSetListPage;
            updateAccountSetPresenter.InitView(IsPostBack);
        }

        private void ToAccountSetListPage()
        {
            Response.Redirect("AccountSetList.aspx", false);
        }
    }
}