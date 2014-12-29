//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetUnderlingAsessHistoryPresenter.cs
// ������: ������
// ��������: 2008-06-19
// ����: ��Ӳ�ѯ��Ϊ���ܿ������˵���ʷ�����
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class GetUnderlingAsessHistoryPresenter : SEP.Presenter.Core.BasePresenter
    {
        private readonly IGetAssessActivityHistoryView _View;

        public GetUnderlingAsessHistoryPresenter(IGetAssessActivityHistoryView view, Account loginUser)
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
            _View.AssessActivitys = AssessActivityLogic.GetAssessActivityHistoryByEmployeeName(LoginUser.Name, _View.pagerEntity);
        }

        public string ExportLeaderEvent(string employeeTemplateLocation)
        {
            return InstanceFactory.AssessActivityFacade().ExportLeaderAssessForm(Convert.ToInt32(_View.AssessActivityId), employeeTemplateLocation);
        }

        public string ExportSelfEvent(string employeeTemplateLocation)
        {
            return InstanceFactory.AssessActivityFacade().ExportEmployeeSelfAssessForm(Convert.ToInt32(_View.AssessActivityId), employeeTemplateLocation);
        }

      

      
    }
}
