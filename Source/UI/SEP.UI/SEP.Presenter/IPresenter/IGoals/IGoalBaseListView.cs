//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IGoalBaseListView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 目标列表接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Model.Goals;

namespace SEP.Presenter.IPresenter.IGoals
{
    public interface IGoalBaseListView
    {
        string DetailRoot { get;set;}

        string UpdateRoot { get;set;}

       // string HostID { get; set;}

        string Message { get;set;}

        List<Goal> GoalList { get;set;}
    }
}
