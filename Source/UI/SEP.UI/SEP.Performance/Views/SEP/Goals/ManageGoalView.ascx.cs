//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ManageGoalView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-05
// 概述: 管理目标
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.IGoals;

namespace SEP.Performance.Views
{
    public partial class ManageGoalView : UserControl, IGoalBaseView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowInfo.Visible = !(String.IsNullOrEmpty(lblResultMessage.Text));
        }

        #region

        public string GoalID
        {
            set { txtID.Text = value; }
            get { return txtID.Text; }
        }

        public string Title
        {
            set { txtTitle.Text = value; }
            get { return txtTitle.Text.Trim(); }
        }

        public string Content
        {
            set { txtContent.Text = value; }
            get { return txtContent.Text.Trim(); }
        }

        public string SetTime
        {
            set { dtpSetTime.Text = value; }
            get { return dtpSetTime.Text.Trim(); }
        }

        //public string HostID
        //{
        //    get { return lblHostID.Text; }
        //    set { lblHostID.Text = value; }
        //}

        //public string HostName
        //{
        //    get { return lblHostName.Text; }
        //    set { lblHostName.Text = value; }
        //}

        public string ResultMessage
        {
            set
            {
                lblResultMessage.Text = value;
                ShowInfo.Visible = !(String.IsNullOrEmpty(value));
            }
            get { return lblResultMessage.Text; }
        }

        public string ValidateTitle
        {
            set { lblValidateTitle.Text = value; }
            get { return lblValidateTitle.Text; }
        }

        public string ValidateSetTime
        {
            set { lblValidateSetTime.Text = value; }
            get { return lblValidateSetTime.Text; }
        }

        #endregion

        public bool IsEdit
        {
            set
            {
                txtTitle.ReadOnly = !value;
                txtContent.ReadOnly = !value;
                dtpSetTime.ReadOnly = !value;
            }
        }

        public EventHandler btnOKClick;

        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
        }
    }
}