//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: LastCompanyGoal.cs
// 创建者: 王玥琦
// 创建日期: 2008-07-9
// 概述: 查看最新公司目标
// ----------------------------------------------------------------
using System.Web.UI.WebControls;
using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Model.Goals;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class LastCompanyGoalPresenter : BasePresenter
    {
        private readonly IGoalBll _GetGoal = BllInstance.GoalBllInstance;
        public readonly IGoalLastCompanyView _IGoalLastCompanyView;

        public LastCompanyGoalPresenter(IGoalLastCompanyView view, Account loginUser)
            : base(loginUser)
        {
            _IGoalLastCompanyView = view;
        }

        public void InitGoal(bool isPostBack)
        {
            if (!isPostBack)
            {
                CompanyGoal companyGoal = _GetGoal.GetLastCompanyGoal(LoginUser);
                _IGoalLastCompanyView.CompanyGoal = companyGoal;
            }
        }

        public delegate void ToCompanyGoalDetailPage(int goalID);

        public ToCompanyGoalDetailPage _ToCompanyGoalDetailPage;

        #region Command

        public void CompanyGoal_Command(object sender, CommandEventArgs e)
        {
            int _GoalID;
            if (!int.TryParse(e.CommandArgument.ToString(), out _GoalID))
            {
                _IGoalLastCompanyView.ResultMessage = "目标ID不存在";
                return;
            }
            _ToCompanyGoalDetailPage(_GoalID);
        }

        #endregion

        public override void Initialize(bool isPostBack)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }
    }
}