//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IGoalLastCompanyView.cs
// 创建者: 王玥琦
// 创建日期: 2008-07-9
// 概述: 查看最新公司目标接口
// ----------------------------------------------------------------
using SEP.Model.Goals;

namespace SEP.Presenter.IPresenter.IGoals
{
    public interface IGoalLastCompanyView
    {
        CompanyGoal CompanyGoal { set; get;}
        string ResultMessage { set; get;}
    }
}
