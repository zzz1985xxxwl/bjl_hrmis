//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GoalAllLastView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-23
// 概述: 增加GoalAllLastView
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;

namespace SEP.Performance.Views
{
    public partial class GoalAllLastView : UserControl,IGoalAllLastView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgAdd.Visible = IsEditGoal;
            ImgTEdit.Visible = IsEditGoal & IsEditTeamGoal;
            ImgAddGray.Visible = !IsEditGoal;
            ImgTEditGray.Visible = !(IsEditGoal & IsEditTeamGoal);
            lbtnAddTeamGoal.Enabled = IsEditGoal;
            lbtnUpdateTeamGoal.Enabled = IsEditGoal & IsEditTeamGoal;
        }

        public bool PersonalGoalVisible
        {
            get { return lbtnPersonalGoal.Visible; }
            set { lbtnPersonalGoal.Visible=value; }
        }

        public bool TeamGoalVisible
        {
            get { return lbtnTeamGoal.Visible; }
            set { lbtnTeamGoal.Visible = value; }
        }

        public bool CompanyGoalVisible
        {
            get { return lbtnCompanyGoal.Visible; }
            set { lbtnCompanyGoal.Visible = value; }
        }

        public CompanyGoal CompanyGoal
        {
            set
            {
                if (value==null)
                {
                    lbtnCompanyGoal.Text = "";
                    return;
                }
                lbtnCompanyGoal.Text = value.Title;
                lbtnCompanyGoal.CommandArgument = value.Id.ToString();
            }
            get { return null;}
        }
        private bool IsEditTeamGoal;
        public bool IsEditGoal;
        public TeamGoal TeamGoal
        {
            set
            {
                if (value == null)
                {
                    lbtnTeamGoal.Text = "";
                    ImgTEdit.Visible = false;
                    ImgTEditGray.Visible = true;
                    lbtnUpdateTeamGoal.Enabled = false;
                    IsEditTeamGoal = false;
                }
                else
                {
                    ImgTEdit.Visible = true;
                    ImgTEditGray.Visible = false;
                    lbtnUpdateTeamGoal.Enabled = true;
                    IsEditTeamGoal = true;
                    lbtnTeamGoal.Text = value.Title;
                    lbtnUpdateTeamGoal.CommandArgument = value.Id.ToString();
                    lbtnTeamGoal.CommandArgument = value.Id.ToString();
                }
            }
            get { return null;}
        }
        public PersonalGoal PersonalGoal
        {
            set
            {
                if (value == null)
                {
                    lbtnPersonalGoal.Text = "";
                    ImgPEdit.Visible = false;
                    ImgPEditGray.Visible = true;
                    lbtnUpdatePersonalGoal.Enabled = false;
                }
                else
                {
                    ImgPEdit.Visible = true;
                    ImgPEditGray.Visible = false;
                    lbtnUpdatePersonalGoal.Enabled = true;
                    lbtnPersonalGoal.Text = value.Title;
                    lbtnUpdatePersonalGoal.CommandArgument = value.Id.ToString();
                    lbtnPersonalGoal.CommandArgument = value.Id.ToString();
                }
            }
            get { return null;}
        }

        public string ResultMessage
        {
            set { lblResultMessage.Text = value; }
            get { return null;}
        }

        public CommandEventHandler CompanyGoal_Command;
        public CommandEventHandler TeamGoal_Command;
        public CommandEventHandler PersonalGoal_Command;
        public CommandEventHandler AddTeamGoal_Command;
        public CommandEventHandler AddPersonalGoal_Command;
        public CommandEventHandler UpdateTeamGoal_Command;
        public CommandEventHandler UpdatePersonalGoal_Command;
        protected void lbtnCompanyGoal_Command(object sender, CommandEventArgs e)
        {
            CompanyGoal_Command(sender, e);
        }
        protected void lbtnTeamGoal_Command(object sender, CommandEventArgs e)
        {
            TeamGoal_Command(sender, e);
        }
        protected void lbtnPersonalGoal_Command(object sender, CommandEventArgs e)
        {
            PersonalGoal_Command(sender, e);
        }
        protected void lbtnAddTeamGoal_Command(object sender, CommandEventArgs e)
        {
            AddTeamGoal_Command(sender, e);
        }
        protected void lbtnAddPersonalGoal_Command(object sender, CommandEventArgs e)
        {
            AddPersonalGoal_Command(sender, e);
        }
        protected void lbtnUpdateTeamGoal_Command(object sender, CommandEventArgs e)
        {
            UpdateTeamGoal_Command(sender, e);
        }
        protected void lbtnUpdatePersonalGoal_Command(object sender, CommandEventArgs e)
        {
            UpdatePersonalGoal_Command(sender, e);
        }

    }
}