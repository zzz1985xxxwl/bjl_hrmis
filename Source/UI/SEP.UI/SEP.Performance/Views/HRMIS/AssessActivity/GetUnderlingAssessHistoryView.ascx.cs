//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetUnderlingAssessHistoryView.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-19
// 概述: 添加查询本人对他人考评的考评活动界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Common.DataAccess;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Presenter.Core;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class GetUnderlingAssessHistoryView : UserControl, IGetAssessActivityHistoryView
    {
        private List<hrmisModel.AssessActivity> _AssessActivitys;
        public int AssessActivitysCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
        }
        private object _AssessActivityId;
        public object AssessActivityId
        {
            get
            {
                return _AssessActivityId;
            }
        }

        public List<hrmisModel.AssessActivity> AssessActivitys
        {
            set
            {
                _AssessActivitys = value;
                dgUnderlingAssessHistorylist.DataSource = value;
                dgUnderlingAssessHistorylist.DataBind();
                hfCount.Value = value.Count.ToString();
                if (value.Count > 0)
                {
                    tbManager.Style["display"] = "block";
                }
                else
                {
                    tbManager.Style["display"] = "none";
                }
            }
        }

        public PagerEntity pagerEntity
        {
            get { return new PagerEntity() { PageIndex = dgUnderlingAssessHistorylist.PageIndex, PageSize = dgUnderlingAssessHistorylist.PageSize }; }
        }


        public EventHandler BindAssessActivity;
        public EventHandler CaculateCount;
        protected void dgUnderlingAssessHistorylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindAssessActivity(null, null);
            dgUnderlingAssessHistorylist.PageIndex = e.NewPageIndex;
            dgUnderlingAssessHistorylist.DataSource = _AssessActivitys;
            dgUnderlingAssessHistorylist.DataBind();
            CaculateCount(null, null);
        }

        protected void btnManualDetail_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManualAssessDetail.aspx?" + ConstParameters.AssessActivityID + "=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void dgUnderlingAssessHistorylist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void dgUnderlingAssessHistorylist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessBasicInfo.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        public event DelegateID btnExportSelfClick;
        protected void btnExportSelf_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportSelfClick(_AssessActivityId.ToString());
        }

        public event DelegateID btnExportLeaderClick;
        protected void btnExportLeader_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportLeaderClick(_AssessActivityId.ToString());
        }

        public event DelegateID btnExportEmployeeSummaryClick;
        protected void btnExportEmployeeSummary_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportEmployeeSummaryClick(_AssessActivityId.ToString());
        }

        public event DelegateID btnExportAssessFormClick;
        protected void btnExportAssessForm_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportAssessFormClick(_AssessActivityId.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(dgUnderlingAssessHistorylist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindAssessActivity(null, null);
            dgUnderlingAssessHistorylist.PageIndex = pageindex;
            dgUnderlingAssessHistorylist.DataSource = _AssessActivitys;
            dgUnderlingAssessHistorylist.DataBind();
            CaculateCount(null, null);
        }
    }
}