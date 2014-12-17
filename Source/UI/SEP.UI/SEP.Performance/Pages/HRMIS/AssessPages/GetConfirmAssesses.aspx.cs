//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: GetConfirmAssesses.cs
// ������: ���޾�
// ��������: 2008-06-17
// ����: ȷ�Ͽ����
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AssessActivity;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class GetConfirmAssesses : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A704))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            }

            GetConfirmAssessesPresenter itsPresenter = new GetConfirmAssessesPresenter(GetConfirmAssessesView1, LoginUser);
            itsPresenter.Initialize(IsPostBack);
        }
    }
}
