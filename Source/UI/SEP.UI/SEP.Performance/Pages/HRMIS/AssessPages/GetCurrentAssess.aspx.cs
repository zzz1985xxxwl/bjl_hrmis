//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: GetCurrentAssess.aspx.cs
// ������: �ߺ�
// ��������: 2008-06-23
// ����: ��ȡ��ǰ��¼�����д���д�Ŀ����
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.AssessActivity;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class GetCurrentAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCurrentAssessPresenter itsPresenter = new GetCurrentAssessPresenter(GetCurrentAssess1, LoginUser);
            itsPresenter.Initialize(IsPostBack);
        }
    }
}
