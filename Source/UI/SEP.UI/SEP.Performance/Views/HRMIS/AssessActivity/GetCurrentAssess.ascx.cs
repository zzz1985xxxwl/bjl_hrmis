//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: GetCurrentAssess.ascx.cs
// 创建者: 倪豪
// 创建日期: 2008-06-23
// 概述: 获取当前登录人所有待填写的考评活动的view
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
    public partial class GetCurrentAssess : UserControl, IGetCurrentAssessView
    {
        private const string _JustForTestError = "该属性仅仅用于测试";

        public string Message
        {
            get
            {
                throw new ArgumentNullException(_JustForTestError);
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public event EventHandler CaculateCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplateSelf = ViewUtility.GetPageTemplate(gvSelf, "PageTemplateSelf");
            PageTemplate PageTemplateManager = ViewUtility.GetPageTemplate(gvManager, "PageTemplateManager");
            PageTemplate PageTemplateCEO = ViewUtility.GetPageTemplate(gvCeo, "PageTemplateCEO");
            PageTemplate PageTemplateHR = ViewUtility.GetPageTemplate(gvHr, "PageTemplateHR");
            PageTemplate PageTemplateSummarize = ViewUtility.GetPageTemplate(gvSummarizeCommment, "PageTemplateSummarize");

            if (PageTemplateSelf != null)
            {
                PageTemplateSelf.LinkButtonGoPageClickdelegate += LinkButtonSelfGoPage_Click;
            }
            if (PageTemplateManager != null)
            {
                PageTemplateManager.LinkButtonGoPageClickdelegate += LinkButtonManagerGoPage_Click;
            }
            if (PageTemplateCEO != null)
            {
                PageTemplateCEO.LinkButtonGoPageClickdelegate += LinkButtonCEOGoPage_Click;
            }
            if (PageTemplateHR != null)
            {
                PageTemplateHR.LinkButtonGoPageClickdelegate += LinkButtonHRGoPage_Click;
            }
            if (PageTemplateSummarize != null)
            {
                PageTemplateSummarize.LinkButtonGoPageClickdelegate += LinkButtonSummarizeGoPage_Click;
            }
        }

        protected void LinkButtonSelfGoPage_Click(int pageindex)
        {
            BindSelfAssessActivity(null, null);
            gvSelf.PageIndex = pageindex;
            gvSelf.DataSource = _SelfSource;
            gvSelf.DataBind();
            CaculateCount(null, null);
        }

        protected void LinkButtonManagerGoPage_Click(int pageindex)
        {
            BindManagerAssessActivity(null, null);
            gvManager.PageIndex = pageindex;
            gvManager.DataSource = _ManagerSource;
            gvManager.DataBind();
            CaculateCount(null, null);
        }

        protected void LinkButtonCEOGoPage_Click(int pageindex)
        {
            BindCeoAssessActivity(null, null);
            gvCeo.PageIndex = pageindex;
            gvCeo.DataSource = _CeoSource;
            gvCeo.DataBind();
            CaculateCount(null, null);
        }

        protected void LinkButtonHRGoPage_Click(int pageindex)
        {
            BindHrAssessActivity(null, null);
            gvHr.PageIndex = pageindex;
            gvHr.DataSource = _HrSource;
            gvHr.DataBind();
            CaculateCount(null, null);
        }

        protected void LinkButtonSummarizeGoPage_Click(int pageindex)
        {
            BindSummarizeCommmentAssessActivity(null, null);
            gvSummarizeCommment.PageIndex = pageindex;
            gvSummarizeCommment.DataSource = _SummarizeCommmentSource;
            gvSummarizeCommment.DataBind();
            CaculateCount(null, null);
        }

        #region 人事填写

        public int HrCount
        {
            get { return Convert.ToInt32(hfHr.Value); }
        }

        private List<hrmisModel.AssessActivity> _HrSource;
        public List<hrmisModel.AssessActivity> HrSource
        {
            get
            {
                return _HrSource;
            }
            set
            {
                _HrSource = value;
                gvHr.DataSource = value;
                gvHr.DataBind();
                hfHr.Value = value.Count.ToString();
                if (value.Count > 0)
                {
                    tbHr.Style["display"] = "block";
                }
                else
                {
                    tbHr.Style["display"] = "none";
                }
            }
        }

        public event EventHandler BindHrAssessActivity;
        protected void gvHr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindHrAssessActivity(null, null);
            gvHr.PageIndex = e.NewPageIndex;
            gvHr.DataSource = _HrSource;
            gvHr.DataBind();
            CaculateCount(null, null);
        }

        protected void gvHr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessBasicInfoBack.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void gvHr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void btnHr_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("HRFillAssess.aspx?" + ConstParameters.AssessActivityID + "=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()) + "&submitID=" +
                              SecurityUtil.DECEncrypt("0"));
        }

        #endregion

        #region 员工填写

        public int SelfCount
        {
            get { return Convert.ToInt32(hfSelf.Value); }
        }

        private List<hrmisModel.AssessActivity> _SelfSource;
        public List<hrmisModel.AssessActivity> SelfSource
        {
            get
            {
                return _SelfSource;
            }
            set
            {
                _SelfSource = value;
                gvSelf.DataSource = value;
                gvSelf.DataBind();
                hfSelf.Value = value.Count.ToString();
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

        public event EventHandler BindSelfAssessActivity;
        protected void gvSelf_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindSelfAssessActivity(null, null);
            gvSelf.PageIndex = e.NewPageIndex;
            gvSelf.DataSource = _SelfSource;
            gvSelf.DataBind();
            CaculateCount(null, null);
        }

        protected void btnSelf_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("PersonalFillAssess.aspx?" + ConstParameters.AssessActivityID + "=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()) + "&submitID=" +
                              SecurityUtil.DECEncrypt("0"));
        }
        
        protected void gvSelf_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(
                        string.Format("AssessBasicInfo.aspx?assessActivityID={0}",
                                      SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void gvSelf_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        #endregion

        #region 主管填写

        public int ManagerCount
        {
            get { return Convert.ToInt32(hfManager.Value); }
        }

        private List<hrmisModel.AssessActivity> _ManagerSource;
        public List<hrmisModel.AssessActivity> ManagerSource
        {
            get
            {
                return _ManagerSource;
            }
            set
            {
                _ManagerSource = value;
                gvManager.DataSource = value;
                gvManager.DataBind();
                hfManager.Value = value.Count.ToString();
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

        public event EventHandler BindManagerAssessActivity;

        protected void gvManager_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindManagerAssessActivity(null, null);
            gvManager.PageIndex = e.NewPageIndex;
            gvManager.DataSource = _ManagerSource;
            gvManager.DataBind();
            CaculateCount(null, null);
        }

        protected void btnManager_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManagerFillAssess.aspx?" + ConstParameters.AssessActivityID + "=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()) + "&submitID=" +
                              SecurityUtil.DECEncrypt("0"));
        }
        
        protected void gvManager_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessBasicInfo.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void gvManager_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        #endregion

        #region 评语

        public int CEOCount
        {
            get { return Convert.ToInt32(hfCEO.Value); }
        }

        private List<hrmisModel.AssessActivity> _CeoSource;
        public List<hrmisModel.AssessActivity> CeoSource
        {
            get
            {
                return _CeoSource;
            }
            set
            {
                _CeoSource = value;
                gvCeo.DataSource = value;
                gvCeo.DataBind();
                hfCEO.Value = value.Count.ToString();
                if (value.Count > 0)
                {
                    tbCEO.Style["display"] = "block";
                }
                else
                {
                    tbCEO.Style["display"] = "none";
                }
            }
        }

        public event EventHandler BindCeoAssessActivity;
        protected void gvCeo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindCeoAssessActivity(null, null);
            gvCeo.PageIndex = e.NewPageIndex;
            gvCeo.DataSource = _CeoSource;
            gvCeo.DataBind();
            CaculateCount(null, null);
        }

        protected void btnCeo_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("CEOFillAssess.aspx?" + ConstParameters.AssessActivityID + "=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()) + "&submitID=" +
                              SecurityUtil.DECEncrypt("0"));
        }

        protected void gvCeo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessBasicInfo.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void gvCeo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        #endregion

        #region 总结评语

        public int SummarizeCommmentCount
        {
            get { return Convert.ToInt32(hfSummarizeCommment.Value); }
        }

        private List<hrmisModel.AssessActivity> _SummarizeCommmentSource;
        public List<hrmisModel.AssessActivity> SummarizeCommmentSource
        {
            get
            {
                return _SummarizeCommmentSource;
            }
            set
            {
                _SummarizeCommmentSource = value;
                gvSummarizeCommment.DataSource = value;
                gvSummarizeCommment.DataBind();
                hfSummarizeCommment.Value = value.Count.ToString();
                if (value.Count > 0)
                {
                    tbSummarizeCommment.Style["display"] = "block";
                }
                else
                {
                    tbSummarizeCommment.Style["display"] = "none";
                }
            }
        }

        public event EventHandler BindSummarizeCommmentAssessActivity;
        protected void gvSummarizeCommment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindSummarizeCommmentAssessActivity(null, null);
            gvSummarizeCommment.PageIndex = e.NewPageIndex;
            gvSummarizeCommment.DataSource = _SummarizeCommmentSource;
            gvSummarizeCommment.DataBind();
            CaculateCount(null, null);
        }

        protected void gvSummarizeCommment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(
                        string.Format("AssessBasicInfo.aspx?assessActivityID={0}",
                                      SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void gvSummarizeCommment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void btnSummarizeCommment_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("SummarizeCommmentFillAssess.aspx?" + ConstParameters.AssessActivityID + "=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()) + "&submitID=" +
                              SecurityUtil.DECEncrypt("0"));
        }

        #endregion
    }
}