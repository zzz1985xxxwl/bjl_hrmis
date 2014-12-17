//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BaseDeleteGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-17
// 概述: 删除目标基类
// ----------------------------------------------------------------
using System;
using System.Web.UI.WebControls;
using SEP.IBll;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;


namespace SEP.Presenter.Goals
{
    public class BaseDeleteGoalPresenter : BasePresenter
    {
        public readonly IGoalBaseListView _IGoalBaseListView;
        public BaseDeleteGoalPresenter(IGoalBaseListView view, Account loginUser)
            : base(loginUser)
        {
            _IGoalBaseListView = view;
        }
        public EventHandler _CompleteEvent;
        public void ExecuteEvent(object sender, CommandEventArgs e)
        {
            int _GoalID;
            if (!int.TryParse(e.CommandArgument.ToString(), out _GoalID))
            {
                _IGoalBaseListView.Message = "目标ID不正确";
                return;
            }
            try
            {
                BllInstance.GoalBllInstance.DeleteGoal(_GoalID, LoginUser);
                _CompleteEvent(this, EventArgs.Empty);
            }
            catch (ApplicationException ex)
            {
                _IGoalBaseListView.Message = ex.Message;
            }

        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}

