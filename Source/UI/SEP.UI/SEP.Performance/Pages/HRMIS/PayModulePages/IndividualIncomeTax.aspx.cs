//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IndividualIncomeTax.cs
// ������: Ѧ����
// ��������: 2008-12-29
// ����: ����˰�ƽ���
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
                throw new ApplicationException("û��Ȩ�޷���");
            }
        }
    }
}