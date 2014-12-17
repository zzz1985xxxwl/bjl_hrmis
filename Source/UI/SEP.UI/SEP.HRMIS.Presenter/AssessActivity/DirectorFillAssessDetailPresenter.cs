//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: DirectorFillAssessDetailPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: ��ʾ�ܼ࿼����д��Ϣ
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class DirectorFillAssessDetailPresenter : DirectorFillAssessPresenter
    {
        public DirectorFillAssessDetailPresenter(string strAssessActivityID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityID, view, loginUser)
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