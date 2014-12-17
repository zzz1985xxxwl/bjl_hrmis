//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DetailCompanyGoalPresenter.cs
// ������: ���h��
// ��������: 2008-06-20
// ����: ��˾Ŀ������
// ----------------------------------------------------------------


using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class DetailCompanyGoalPresenter : ShowCompanyGoalPresenter//AdminBasePresenter
    {
        public DetailCompanyGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(view, loginUser)
        {
        }
    }
}
