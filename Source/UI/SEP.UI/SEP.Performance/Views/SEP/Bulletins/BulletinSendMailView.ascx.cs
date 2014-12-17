//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinSendMailView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinSendMailView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.IPresenter.IBulletins;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Bulletins
{
    public partial class BulletinSendMailView : UserControl, ISendMailForBulletinView
    {
        private int _EmployeeID;
        private string _EmployeeNameForRight;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            message.Visible = false;
            if (!IsPostBack)
            {
                if (InitView != null)
                {
                    InitView(this, EventArgs.Empty);
                }
            }
        }

        #region 接口实现

        public int BulletinID
        {
            get { return Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["BulletinID"])); }
            set { }
        }

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        public string EmployeeNameForRight
        {
            get { return _EmployeeNameForRight; }
            set { _EmployeeNameForRight = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
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

        public string MessageFromBll
        {
            get { return lblMessage.Text.Trim(); }
            set
            {
                lblMessage.Text = value;
                message.Visible = !string.IsNullOrEmpty(MessageFromBll);
            }
        }

        public string BulletinTitle
        {
            get { return lblBulletinTitle.Text.Trim(); }
            set { lblBulletinTitle.Text = value; }
        }

        public List<Account> EmployeeRight
        {
            get { return ViewState["EmployeeRight"] as List<Account>; }
            set { ViewState["EmployeeRight"] = value; }
        }

        public List<Account> EmployeeLeft
        {
            get { return ViewState["EmployeeLeft"] as List<Account>; }
            set
            {
                ViewState["EmployeeLeft"] = value;
                EmployeeSearched.DataSource = value;
                EmployeeSearched.DataValueField = "Id";
                EmployeeSearched.DataTextField = "Name";
                EmployeeSearched.DataBind();
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
                        ddlDepartment.Items.Add(department.Name);
                        ddlDepartment.Items[i].Value = department.Id.ToString();
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
                        ddlPosition.Items[i].Value = position.Id.ToString();
                        i++;
                    }
                }
            }
        }

        public event EventHandler SearchEmployeeEvent;
        public event EventHandler SendMailEvent;
        public event EventHandler ToRightEvent;
        public event EventHandler ToLeftEvent;
        public event EventHandler InitView;

        #endregion

        protected void SendMail_Click(object sender, EventArgs e)
        {
            if (SendMailEvent != null)
            {
                SendMailEvent(this, EventArgs.Empty);
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (SearchEmployeeEvent != null)
            {
                SearchEmployeeEvent(this, EventArgs.Empty);
            }
        }

        protected void ToRight_Click(object sender, EventArgs e)
        {
            foreach (int i in EmployeeSearched.GetSelectedIndices())
            {
                EmployeeID = Convert.ToInt32(EmployeeSearched.Items[i].Value);
                EmployeeNameForRight = EmployeeSearched.Items[i].Text;
                ToRightEvent(this, EventArgs.Empty);
            }
            BindEmployeeToSend();
        }

        protected void ToLeft_Click(object sender, EventArgs e)
        {
            foreach (int i in EmployeeToSend.GetSelectedIndices())
            {
                EmployeeID = Convert.ToInt32(EmployeeToSend.Items[i].Value);
                ToLeftEvent(this, EventArgs.Empty);
            }
            BindEmployeeToSend();
        }

        private void BindEmployeeToSend()
        {
            EmployeeToSend.DataSource = EmployeeRight;
            EmployeeToSend.DataValueField = "Id";
            EmployeeToSend.DataTextField = "Name";
            EmployeeToSend.DataBind();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BulletinListBack.aspx");
        }
    }
}