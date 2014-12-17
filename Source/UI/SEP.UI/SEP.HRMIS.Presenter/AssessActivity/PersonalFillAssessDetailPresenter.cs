//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: PersonalFillAssessDetailPresenter.cs
// 创建者:wang.shali
// 创建日期: 2008-06-16
// 概述: 显示个人考评填写信息
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class PersonalFillAssessDetailPresenter : PersonalFillAssessPresenter
    {
        public PersonalFillAssessDetailPresenter(string strAssessActivityId, string submitID, IAssessAnswerView view, Account loginUser)
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
