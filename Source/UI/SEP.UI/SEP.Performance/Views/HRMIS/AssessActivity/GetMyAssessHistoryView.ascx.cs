//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetMyAssessHistoryView.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-19
// 概述: 添加查询本人考评活动的界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Presenter.Core;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class GetMyAssessHistoryView : UserControl, IGetAssessActivityHistoryView
    {
        private List<hrmisModel.AssessActivity> _AssessActivitys;
        //private const string _JustForTestError = "该属性仅仅用于测试";
        public int AssessActivitysCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
        }
        public int _Count; private object _AssessActivityId;
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
                dgMyAssessHistorylist.DataSource = value;
                dgMyAssessHistorylist.DataBind();
                hfCount.Value = value.Count.ToString();
                if (value.Count > 0)
                {
                    tbSelf.Style["display"] = "block";
                }
                else
                {
                    tbSelf.Style["display"] = "none";
                }
            }
        }
        public EventHandler BindAssessActivity;
        public EventHandler CaculateCount;
        protected void dgMyAssessHistorylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindAssessActivity(null, null);
            dgMyAssessHistorylist.PageIndex = e.NewPageIndex;
            dgMyAssessHistorylist.DataSource = _AssessActivitys;
            dgMyAssessHistorylist.DataBind();
            CaculateCount(null, null);
        }

        //protected void dgMyAssessHistorylist_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case "HiddenPostButtonCommand":
        //            Response.Redirect(string.Format("AssessBasicInfo.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
        //            return;
        //    }
        //}

        protected void dgMyAssessHistorylist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public event DelegateID btnExportSelfClick;
        public event DelegateID btnExportAllClick;
        protected void btnExportSelf_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportSelfClick(_AssessActivityId.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(dgMyAssessHistorylist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindAssessActivity(null, null);
            dgMyAssessHistorylist.PageIndex = pageindex;
            dgMyAssessHistorylist.DataSource = _AssessActivitys;
            dgMyAssessHistorylist.DataBind();
            CaculateCount(null, null);
        }

        protected void btnExportAll_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportAllClick(_AssessActivityId.ToString());
        }
    }
}
        
    
