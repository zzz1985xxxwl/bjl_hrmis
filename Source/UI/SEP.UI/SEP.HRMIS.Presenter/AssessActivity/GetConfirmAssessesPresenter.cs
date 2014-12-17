//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: GetConfirmAssessesPresenter.cs
// ������: ���޾�
// ��������: 2008-06-17
// ����: ȷ�Ͽ����
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class GetConfirmAssessesPresenter : SEP.Presenter.Core.BasePresenter
    {
        private const string _AssessActivityIdError = "��ı�ʶ��ȡ��������ϵ����Ա";

        private readonly IGetConfirmAssessesView _ItsView;

        public GetConfirmAssessesPresenter(IGetConfirmAssessesView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public override void Initialize(bool isPostBack)
        {
            _ItsView.Message = string.Empty;
            if (!isPostBack)
            {
                BindAssessActivity(null, null);
            }
        }

        private void  BindAssessActivity(object sender, EventArgs e)
        {
            _ItsView.AssessActivitys = 
                AssessActivityLogic.GetAssessActivityByEmployeeStatus(-1, AssessStatus.HRComfirming);
        }

        private void AttachViewEvent()
        {
            _ItsView.ConfirmAssessEvent += ConfirmAssessEvent;
            _ItsView.BindAssessActivity += BindAssessActivity;
        }

        private void ConfirmAssessEvent(object sender, EventArgs e)
        {
            int assessActivityID = ConvertToInt(_ItsView.AssessActivityID);
            if (!assessActivityID.Equals(0))
            {
                return;
            }

        }

        private int ConvertToInt(object id)
        {
            try
            {
                return int.Parse(id.ToString());
            }
            catch
            {
                _ItsView.Message = _AssessActivityIdError;
                return 0;
            }
        }
    }
}
