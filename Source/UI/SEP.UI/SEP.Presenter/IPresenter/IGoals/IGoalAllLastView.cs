//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IGoalAllLastView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 查看最新目标接口
// ----------------------------------------------------------------
using SEP.Model.Goals;
using CompanyGoal=SEP.Model.Goals.CompanyGoal;
using TeamGoal=SEP.Model.Goals.TeamGoal;

namespace SEP.Presenter.IPresenter.IGoals
{
    public interface IGoalAllLastView
    {
        CompanyGoal CompanyGoal { set; get;}
        TeamGoal TeamGoal { set; get;}
        PersonalGoal PersonalGoal { set; get;}
        bool PersonalGoalVisible { set; get;}
        bool TeamGoalVisible{ set; get;}
        bool CompanyGoalVisible { set; get;}
        string ResultMessage { set; get;}
    }
}
