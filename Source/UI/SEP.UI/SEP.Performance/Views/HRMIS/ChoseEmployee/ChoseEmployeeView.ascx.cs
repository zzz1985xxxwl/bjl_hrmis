//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ChoseAccountView.cs
// 创建者: 薛文龙
// 创建日期: 2008-08-28
// 概述: 增加ChoseAccountView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.ChoseEmployee
{
    public partial class ChoseEmployeeView : UserControl, IChoseEmployeeView
    {
        protected void Page_Load(object sender, EventArgs e)
         {
             if (!IsPostBack)
             {
                 if (InitView != null)
                 {
                     InitView(null, null);
                 }

             }
         }

        private int _AccountID;
        private string _AccountNameForRight;
        private string _AccountRightViewStateName;
        private string _AccountLeftViewStateName;

        public int AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        public string AccountNameForRight
        {
            get { return _AccountNameForRight; }
            set { _AccountNameForRight = value; }
        }

        public string AccountName
        {
            get { return txtAccountName.Text.Trim(); }
            set { }
        }

        public int DepartmentID
        {
            get { return Convert.ToInt32(ddlDepartment.SelectedValue); }
            set { }
        }

        public int PositionID
        {
            get { return Convert.ToInt32(ddlPosition.SelectedValue); }
            set { }
        }

        public string AccountRightViewStateName
        {
            get
            {
                if (string.IsNullOrEmpty(_AccountRightViewStateName))
                {
                    return "AccountRight";
                }
                return _AccountRightViewStateName;
            }
            set { _AccountRightViewStateName = value; }
        }

        public string AccountLeftViewStateName
        {
            get
            {
                if (string.IsNullOrEmpty(_AccountLeftViewStateName))
                {
                    return "AccountLeft";
                }
                return _AccountLeftViewStateName;
            }
            set { _AccountLeftViewStateName = value; }
        }

        public List<Account> AccountRight
        {
            get { return ViewState[AccountRightViewStateName] as List<Account>; }
            set
            {
                ViewState[AccountRightViewStateName] = value;
                AccountToSend.DataSource = value;
                AccountToSend.DataValueField = "Id";
                AccountToSend.DataTextField = "Name";
                AccountToSend.DataBind();
            }
        }

        public List<Account> AccountLeft
        {
            get { return ViewState[AccountLeftViewStateName] as List<Account>; }
            set
            {
                ViewState[AccountLeftViewStateName] = value;
                AccountSearched.DataSource = value;
                AccountSearched.DataValueField = "Id";
                AccountSearched.DataTextField = "Name";
                AccountSearched.DataBind();
            }
        }

        public List<Department> DepartmentList
        {
            get { return null; }
            set
            {
                ddlDepartment.Items.Clear();
                ddlDepartment.Items.Add("");
                ddlDepartment.Items[0].Value = "-1";
                int i = 1;
                if (value != null)
                {
                    foreach (Department department in value)
                    {
                        ddlDepartment.Items.Add(department.DepartmentName);
                        ddlDepartment.Items[i].Value = department.DepartmentID.ToString();
                        i++;
                    }
                }
            }
        }

        public List<Position> PositionList
        {
            get { return null; }
            set
            {
                ddlPosition.Items.Clear();
                ddlPosition.Items.Add("");
                ddlPosition.Items[0].Value = "-1";
                int i = 1;
                if (value != null)
                {
                    foreach (Position position in value)
                    {
                        ddlPosition.Items.Add(position.Name);
                        ddlPosition.Items[i].Value = position.ParameterID.ToString();
                        i++;
                    }
                }
            }
        }

        public event EventHandler SearchAccountEvent;
        public event EventHandler ToRightEvent;
        public event EventHandler ToLeftEvent;
        public event EventHandler InitView;
        public event EventHandler CloseEvent;
        public event EventHandler AttachAccountAjax;
        public event EventHandler SearchAjax;

        public event DelegateNoParameter SavePlanDutyViewState;

        protected void Search_Click(object sender, EventArgs e)
        {
            if (SearchAccountEvent != null)
            {
                SearchAccountEvent(this, EventArgs.Empty);
            }
            if (SearchAjax != null)
            {
                SearchAjax(this, EventArgs.Empty);
            }
            if (SavePlanDutyViewState != null)
            {
                SavePlanDutyViewState();
            }
        }

        protected void ToRight_Click(object sender, EventArgs e)
        {
            foreach (int i in AccountSearched.GetSelectedIndices())
            {
                AccountID = Convert.ToInt32(AccountSearched.Items[i].Value);
                AccountNameForRight = AccountSearched.Items[i].Text;
                ToRightEvent(this, EventArgs.Empty);
            }
            BindAccountToSend();
        }

        private void BindAccountToSend()
        {
            AccountToSend.DataSource = AccountRight;
            AccountToSend.DataValueField = "Id";
            AccountToSend.DataTextField = "Name";
            AccountToSend.DataBind();
            if (AttachAccountAjax != null)
            {
                AttachAccountAjax(this, EventArgs.Empty);
            }
            if (SavePlanDutyViewState != null)
            {
                SavePlanDutyViewState();
            }
        }

        protected void ToLeft_Click(object sender, EventArgs e)
        {
            foreach (int i in AccountToSend.GetSelectedIndices())
            {
                AccountID = Convert.ToInt32(AccountToSend.Items[i].Value);
                ToLeftEvent(this, EventArgs.Empty);
            }
            BindAccountToSend();
        }

        /// <summary>
        /// 关闭小界面设置
        /// </summary>
        public string btnCancelOnClientClick
        {
            set { btnCancel.OnClientClick = value; }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (SavePlanDutyViewState != null)
            {
                SavePlanDutyViewState();
            }
            if (CloseEvent!=null)
            {
                CloseEvent(this,EventArgs.Empty);
            }
        }

    }
}