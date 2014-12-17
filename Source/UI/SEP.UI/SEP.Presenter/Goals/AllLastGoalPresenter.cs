//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AllLastGoalPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 查看最新目标
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
    public class AllLastGoalPresenter : BasePresenter
    {
        private readonly IGoalBll _IGoalBll = BllInstance.GoalBllInstance;
        public readonly IGoalAllLastView _IGoalAllLastView;

        public AllLastGoalPresenter(IGoalAllLastView view, Account loginUser)
            : base(loginUser)
        {
            _IGoalAllLastView = view;
        }

        public void InitGoal(bool isPostBack)
        {
            CompanyGoal companyGoal = _IGoalBll.GetLastCompanyGoal(LoginUser);
            TeamGoal teamGoal = _IGoalBll.GetLastTeamGoalBySetHostID(LoginUser.Dept.Id, LoginUser);
            PersonalGoal personalGoal = _IGoalBll.GetLastPersonalGoalBySetHostID(LoginUser.Id, LoginUser);
            if (personalGoal == null)
            {
                _IGoalAllLastView.PersonalGoalVisible = false;
            }
            if (teamGoal == null)
            {
                _IGoalAllLastView.TeamGoalVisible = false;
            }
            if (companyGoal == null)
            {
                _IGoalAllLastView.CompanyGoalVisible = false;
            }
            _IGoalAllLastView.CompanyGoal = companyGoal;
            _IGoalAllLastView.TeamGoal = teamGoal;
            _IGoalAllLastView.PersonalGoal = personalGoal;
        }

        public bool IsEditGoal()
        {
            if (LoginUser.Dept != null)
            {
                //如果该部门是叶子部门，且员工是部门的领导，则可以新增，编辑团队目标
                return LoginUser.Dept.Leader.Id == LoginUser.Id && LoginUser.Dept.CountChildDept == 0;
            }
            return false;
        }

        public delegate void ToCompanyGoalDetailPage(int goalID);

        public ToCompanyGoalDetailPage _ToCompanyGoalDetailPage;

        public delegate void ToTeamGoalDetailPage(int goalID);

        public ToTeamGoalDetailPage _ToTeamGoalDetailPage;

        public delegate void ToPersonalGoalDetailPage(int goalID);

        public ToPersonalGoalDetailPage _ToPersonalGoalDetailPage;

        #region Command

        public void CompanyGoal_Command(object sender, CommandEventArgs e)
        {
            int _GoalID;
            if (!int.TryParse(e.CommandArgument.ToString(), out _GoalID))
            {
                _IGoalAllLastView.ResultMessage = "目标ID不存在";
                return;
            }
            _ToCompanyGoalDetailPage(_GoalID);
        }

        public void TeamGoal_Command(object sender, CommandEventArgs e)
        {
            int _GoalID;
            if (!int.TryParse(e.CommandArgument.ToString(), out _GoalID))
            {
                _IGoalAllLastView.ResultMessage = "目标ID不存在";
                return;
            }
            _ToTeamGoalDetailPage(_GoalID);
        }

        public void PersonalGoal_Command(object sender, CommandEventArgs e)
        {
            int _GoalID;
            if (!int.TryParse(e.CommandArgument.ToString(), out _GoalID))
            {
                _IGoalAllLastView.ResultMessage = "目标ID不存在";
                return;
            }
            _ToPersonalGoalDetailPage(_GoalID);
        }

        #endregion

        public override void Initialize(bool isPostBack)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }
    }
}