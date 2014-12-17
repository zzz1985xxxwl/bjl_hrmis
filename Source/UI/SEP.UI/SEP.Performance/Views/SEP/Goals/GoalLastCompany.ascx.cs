//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GoalLastCompany.cs
// 创建者: 王玥琦
// 创建日期: 2008-07-09
// 概述: 增加GoalLastCompany
// ----------------------------------------------------------------
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;

namespace SEP.Performance.Views
{
    public partial class GoalLastCompany : UserControl, IGoalLastCompanyView
    {
        public CompanyGoal CompanyGoal
        {
            set
            {
                if (value == null)
                {
                    lbtnCompanyGoal.Text = "";
                    lblCGSetTime.Text = "";
                    lbtnCompanyGoal.Visible = false;
                    return;
                }
                lbtnCompanyGoal.Visible = true;
                lbtnCompanyGoal.Text = value.Title;
                lbtnCompanyGoal.CommandArgument = value.Id.ToString();
                lblCGSetTime.Text = value.SetTime.ToShortDateString();
            }
            get { return null; }
        }

        public string ResultMessage
        {
            set { lblResultMessage.Text = value; }
            get { return null; }
        }

        public CommandEventHandler CompanyGoal_Command;

        protected void lbtnCompanyGoal_Command(object sender, CommandEventArgs e)
        {
            CompanyGoal_Command(sender, e);
        }
    }
}