//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetMyAssessHistoryPresenter.cs
// ������: ������
// ��������: 2008-06-19
// ����: ��Ӳ�ѯ���˵���ʷ�����
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class GetMyAssessHistoryPresenter : SEP.Presenter.Core.BasePresenter
    {
        private readonly IGetAssessActivityHistoryView _View;
        public GetMyAssessHistoryPresenter(IGetAssessActivityHistoryView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }
            _View = view;
        }


        public override void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                BindAssessActivity(null, null);
            }
        }

        public void BindAssessActivity(object sender, EventArgs e)
        {
            _View.AssessActivitys =
                InstanceFactory.AssessActivityFacade.GetMyAssessActivityByAccountId(LoginUser.Id);
        }

        public string ExportSelfEvent(string employeeTemplateLocation)
        {
            return InstanceFactory.AssessActivityFacade.ExportEmployeeSelfAssessForm(Convert.ToInt32(_View.AssessActivityId), employeeTemplateLocation);
        }

      
    }
}
