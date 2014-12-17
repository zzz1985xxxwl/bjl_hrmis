//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SearchEmployeeInAndOutList.cs
// ������:����
// ��������: 2008-10-29
// ����: SearchEmployeeInAndOutList �б� �������޸�ɾ���鿴����
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class SearchEmployeeInAndOutList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A504))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            }
            new SearchEmployeeInAndOutInfoPresenter(PersonalInAndOutInfoView1, LoginUser).Initialize(IsPostBack);
        }
    }
}
