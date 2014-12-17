//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AssessBasicInfoPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: ��ʾ����������Ϣ
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.IFacede;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class AssessBasicInfoPresenter : SEP.Presenter.Core.BasePresenter
    {
        private readonly IAssessBasicInfoView _View;
        private readonly bool _IsBack;
        private readonly string _StrAssessActivityId;

        public AssessBasicInfoPresenter(string strAssessActivityID, IAssessBasicInfoView view, bool isBack, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }

            _StrAssessActivityId = strAssessActivityID;
            _View = view;
            _IsBack = isBack;
        }

        public override void Initialize(bool isPostBack)
        {
            _View.Message = string.Empty;
            _View.IsBack = _IsBack;
            if (isPostBack)
            {
                return;
            }

            int assessActivityID;
            if (!int.TryParse(_StrAssessActivityId, out assessActivityID))
            {
                _View.Message = "��Ч���˻��Ϣ�������";
                return;
            }
            hrmisModel.AssessActivity assessActivity = InstanceFactory.AssessActivityFacade.GetAssessActivityByAssessActivityID(assessActivityID);
            BindInformation(assessActivity);
        }

        private void BindInformation(hrmisModel.AssessActivity assessActivity)
        {
            if (assessActivity != null)
            {
                _View.AssessActivityToShow = assessActivity;
                Account managerInfo =
                    BllInstance.AccountBllInstance.GetLeaderByAccountId(assessActivity.ItsEmployee.Account.Id);
                if (managerInfo != null)
                {
                    managerInfo = BllInstance.AccountBllInstance.GetAccountById(managerInfo.Id);
                    _View.ManagerName = managerInfo.Name;
                }
            }
            else
            {
                _View.Message = "��Ч���˻��Ϣ��ȡʧ��";
            }
        }
    }
}