//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: GetConfirmAssessesView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-06-16
// 概述: 确认考评活动
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class GetConfirmAssessesView : UserControl, IGetConfirmAssessesView
    {
        //private const string _EventError = "The event is null";
        public event EventHandler ConfirmAssessEvent;
        public event EventHandler BindAssessActivity;
        private object _AssessActivityID = CommandEventArgs.Empty;

        protected void btnConfirm_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("ConfirmAssess.aspx?" + ConstParameters.AssessActivityID + "=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void grvitemlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindAssessActivity(null, null);
            grvitemlist.PageIndex = e.NewPageIndex;
            grvitemlist.DataSource = _AssessActivitys;
            grvitemlist.DataBind();
        }


        private List<hrmisModel.AssessActivity> _AssessActivitys;
        public List<hrmisModel.AssessActivity> AssessActivitys
        {
            get
            {
                return _AssessActivitys;
            }
            set
            {
                _AssessActivitys = value;
                grvitemlist.DataSource = value;
                grvitemlist.DataBind();
                if (value.Count > 0)
                {
                    tbAssess.Style["display"] = "block";
                }
                else
                {
                    tbAssess.Style["display"] = "none";
                }
            }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (String.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public object AssessActivityID
        {
            get { return _AssessActivityID; }
        }

        protected void grvitemlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void grvitemlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessBasicInfoBack.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvitemlist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindAssessActivity(null, null);
            grvitemlist.PageIndex = pageindex;
            grvitemlist.DataSource = _AssessActivitys;
            grvitemlist.DataBind();
        }

    }
}

