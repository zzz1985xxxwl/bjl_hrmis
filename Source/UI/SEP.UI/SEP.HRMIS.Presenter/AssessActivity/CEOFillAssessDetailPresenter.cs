//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: CEOFillAssessDetailPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: ��ʾCEO������д��Ϣ
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class CEOFillAssessDetailPresenter : CEOFillAssessPresenter
    {
        public CEOFillAssessDetailPresenter(string strAssessActivityId, string submitID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityId, submitID, view, loginUser)
        {
        }

        public void InitViewDetail(bool isPageValid)
        {
            InitView(isPageValid);
            if (_AssessActivity != null && !isPageValid)
            {
                _View.FormReadonly = true;
            }
        }
    }
}

