//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CompanyLinkManListView.cs
// 创建者: liudan
// 创建日期: 2009-06-30
// 概述: 公司电话薄列表界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;

namespace SEP.Performance.Views.HRMIS.CompanyTeleBooks
{
    using ComService.ServiceModels;

    public partial class CompanyLinkManListView : UserControl, ICompanyLinkListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvLeaveRequestType.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvLeaveRequestType, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        #region ICompanyLinkListView成员

        private List<Linkman> _Linkmans;
        public List<Linkman> Linkmans
        {
            get { return _Linkmans; }
            set
            {
                _Linkmans = value;
                gvLeaveRequestType.DataSource = value;
                gvLeaveRequestType.DataBind();
                lblMessage.Text = value.Count.ToString();
            }
        }

        public event DelegateNoParameter BtnAddEvent;
        public event DelegateGUID BtnUpdateEvent;
        public event DelegateGUID BtnDeleteEvent;
        public event DelegateGUID BtnDetailEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public string ContactName
        {
            get { return txtName.Text; }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }


        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(new Guid(e.CommandArgument.ToString()));
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(new Guid(e.CommandArgument.ToString()));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void gvLeaveRequestType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLeaveRequestType.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvLeaveRequestType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(new Guid(e.CommandArgument.ToString()));
                    return;
            }
        }

        protected void gvLeaveRequestType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }
    }
}