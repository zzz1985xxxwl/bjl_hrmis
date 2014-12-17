//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DepartmentHistoryList.cs
// ������: ���h��
// ��������: 2008-11-13
// ����: �鿴������ʷ
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
                throw new ApplicationException("û��Ȩ�޷���");
            }
            DepartmentHistoryListPresenter thePresenter = new DepartmentHistoryListPresenter(DepartmentHistoryListView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}
