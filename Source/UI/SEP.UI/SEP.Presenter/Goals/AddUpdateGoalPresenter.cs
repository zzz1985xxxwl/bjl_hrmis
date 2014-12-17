//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddUpdateGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-16
// 概述: 增加目标基类
// ----------------------------------------------------------------
using System;
using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class AddUpdateGoalPresenter : BasePresenter
    {
        public IGoalBaseView _IGoalBaseView;

        public AddUpdateGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(loginUser)
        {
            _IGoalBaseView = view;
        }

        public bool Validation()
        {
            DateTime _SetTime;

            _IGoalBaseView.ResultMessage = String.Empty;
            _IGoalBaseView.ValidateTitle = String.Empty;
            _IGoalBaseView.ValidateSetTime = String.Empty;

            if (String.IsNullOrEmpty(_IGoalBaseView.Title))
            {
                _IGoalBaseView.ValidateTitle = "目标标题不能为空！";
                return false;
            }
            if (_IGoalBaseView.Title.Length > 50)
            {
                _IGoalBaseView.ValidateTitle = "目标标题不能超过50个字符！";
                return false;
            }
            if (String.IsNullOrEmpty(_IGoalBaseView.SetTime))
            {
                _IGoalBaseView.ValidateSetTime = "目标设置时间不能为空！";
                return false;
            }
            if (!DateTime.TryParse(_IGoalBaseView.SetTime, out _SetTime))
            {
                _IGoalBaseView.ValidateSetTime = "目标设置时间格式不正确！";
                return false;
            }
            return true;
        }


        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
