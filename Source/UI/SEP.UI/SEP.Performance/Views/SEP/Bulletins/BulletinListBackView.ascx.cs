//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinListBackView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinListBackView
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Departments;
using SEP.Presenter.IPresenter.IBulletins;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Bulletins
{
    public partial class BulletinListBackView : UserControl, IListBulletinBackView
    {
        private List<Model.Bulletins.Bulletin> _BulletinList;
        private int _BulletinID;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ErrorMsg.Visible = false;
            count.Visible = true;
            if (!IsPostBack)
            {
                BindBulletin();
            }
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvBulletinList.PageIndex = pageindex;
            BindBulletin();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvBulletinList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void BulletinList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBulletinList.PageIndex = e.NewPageIndex;
            BindBulletin();
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            if (DeleteBulletin != null)
            {
                BulletinID = Convert.ToInt32(e.CommandArgument);
                DeleteBulletin(this, EventArgs.Empty);
            }
            BindBulletin();
        }

        public List<Model.Bulletins.Bulletin> BulletinList
        {
            get { return _BulletinList; }
            set { _BulletinList = value; }
        }

        public string Title
        {
            get { return txtTitle.Text.Trim(); }
            set { }
        }

        public string PublishStartTime
        {
            get { return txtPublishStartTime.Text.Trim(); }
            set { }
        }

        public string PublishEndTime
        {
            get { return txtPublishEndTime.Text.Trim(); }
            set { }
        }
        public List<Department> DepartmentSource
        {
            set
            {
                listDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty,"-1", true);
                listDepartment.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    listDepartment.Items.Add(item);
                }
            }
        }

        public int DepartmentId
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
        }

        public string Message
        {
            get { return lblMessage.Text.Trim(); }
            set
            {
                lblMessage.Text = value;
                ErrorMsg.Visible = !string.IsNullOrEmpty(lblMessage.Text.Trim());
                count.Visible = string.IsNullOrEmpty(lblMessage.Text.Trim());
            }
        }

        public int BulletinID
        {
            get { return _BulletinID; }
            set { _BulletinID = value; }
        }

        public event EventHandler btnSearchClicked;
        public event EventHandler DeleteBulletin;

        private void BindBulletin()
        {
            if (btnSearchClicked != null)
            {
                btnSearchClicked(this, EventArgs.Empty);
            }
            //if (BulletinList!=null&&BulletinList.Count > 0)
            //{
            gvBulletinList.DataSource = BulletinList;
            gvBulletinList.DataBind();
            if (BulletinList == null || BulletinList.Count <= 0)
            {
                Result.Visible = false;
            }
            else
            {
                Result.Visible = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindBulletin();
        }

        protected void gvBulletinList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(
                        string.Format("BulletinShowDetailBack.aspx?BulletinID={0}",
                                      SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void gvBulletinList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }
    }
}