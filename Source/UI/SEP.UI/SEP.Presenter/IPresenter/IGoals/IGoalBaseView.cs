//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IGoalBaseView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-06
// 概述: 目标基类接口
// ----------------------------------------------------------------

namespace SEP.Presenter.IPresenter.IGoals
{
    public interface IGoalBaseView
    {
        string GoalID { set; get;}
        string Title { set;get;}
        string Content { set;get;}
        string SetTime { set;get;}
        //string HostID { set;get;}
        //string HostName { set;get;}
        string ResultMessage { set;get; }

        string ValidateTitle { set; get;}
        string ValidateSetTime { set; get;}
    }
}
