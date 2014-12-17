//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: LeaveRequestTypeListView.cs
// 创建者: wangshlai
// 创建日期: 2008-08-04
// 概述: 假期类型列表界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.LeaveRequestTypes
{
    public partial class LeaveRequestTypeListView : UserControl, ILeaveRequestTypeListView
    {
        #region ILeaveRequestTypeListView成员

        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public string LeaveRequestTypeName
        {
            get { return txtName.Text.Trim(); }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }
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
        
        private List<LeaveRequestType> _LeaveRequestTypes;

        public List<LeaveRequestType> LeaveRequestTypes
        {
            get { return _LeaveRequestTypes; }
            set
            {
                _LeaveRequestTypes = value;
                gvLeaveRequestType.DataSource = value;
                gvLeaveRequestType.DataBind();
                lblMessage.Text = value.Count.ToString();
            }
        }


        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void gvLeaveRequestType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLeaveRequestType.PageIndex = e.NewPageIndex;
            //gvLeaveRequestType.DataSource = _LeaveRequestTypes;
            //gvLeaveRequestType.DataBind();
            btnSearch_Click(sender, e);
        }

        protected void gvLeaveRequestType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void gvLeaveRequestType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

    }
}