//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetListView.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 帐套列表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;
using SEP.Presenter.Core;
using SEP.HRMIS.Model.PayModule;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    using global::SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet;

    public partial class AccountSetListView : UserControl, IAccountSetListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvAccountSetList.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvAccountSetList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnAddClick();
        }

        public event DelegateNoParameter btnAddClick;
        public event DelegateID btnUpdateClick;
        public event DelegateID btnDeleteClick;
        public event DelegateID btnDetailClick;
        public event DelegateID btnCopyClick;
        public event EventHandler BindAccountSetListSource;
        private List<AccountSet> _AccountSetListDataSource;
        public List<AccountSet> AccountSetListDataSource
        {
            get
            {
                return _AccountSetListDataSource;
            }
            set
            {
                _AccountSetListDataSource = value;
                gvAccountSetList.DataSource = value;
                gvAccountSetList.DataBind();

                if (_AccountSetListDataSource == null || _AccountSetListDataSource.Count == 0)
                {
                    tbAccountSetList.Style["display"] = "none";
                }
                else
                {
                    tbAccountSetList.Style["display"] = "block";

                }
                lblMessage.Text = value.Count.ToString();
            }

        }

        public string AccountSetName
        {
            get { return txtName.Text.Trim(); }
        }

        public AccountSet SessionCopyAccountSet
        {
            get { return Session[AccountSetUtility.SessionCopyAccountSet] as AccountSet; }
            set { Session[AccountSetUtility.SessionCopyAccountSet] = value; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAccountSetListSource(sender, e);
        }
        protected void gvAccountSetList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAccountSetList.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvAccountSetList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    btnDetailClick(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void gvAccountSetList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void lbModify_Click(object sender, CommandEventArgs e)
        {
            btnUpdateClick(e.CommandArgument.ToString());
        }

        protected void lbDelete_Click(object sender, CommandEventArgs e)
        {
            btnDeleteClick(e.CommandArgument.ToString());
        }

        protected void lbCopy_Click(object sender, CommandEventArgs e)
        {
            btnCopyClick(e.CommandArgument.ToString());
        }
    }
}