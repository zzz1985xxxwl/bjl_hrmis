//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DetailPersonalGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-20
// 概述: 个人目标详情
// ----------------------------------------------------------------


using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class DetailPersonalGoalPresenter : ShowPersonalGoalPresenter
    {
        public DetailPersonalGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(view, loginUser)
        {
        }
    }
}
