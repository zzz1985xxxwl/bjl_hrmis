//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DetailCompanyGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-20
// 概述: 公司目标详情
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
