//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: HRFillingAssessPresenter.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-23
// 概述: 添加待人事填写考评活动的界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using hrmisModel = SEP.HRMIS.Model;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class HRFillingAssessView : UserControl, IHRFillingAssessView
    {       
        private string _RedirectPage;

        public string RedirectPage
        {
            set { _RedirectPage = value; }
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
                gvHRFillingAssess.DataSource = value;
                gvHRFillingAssess.DataBind();
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

        public EventHandler BindAssessActivity;
        protected void gvHRFillingAssess_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindAssessActivity(null, null);
            gvHRFillingAssess.PageIndex = e.NewPageIndex;
            gvHRFillingAssess.DataSource = _AssessActivitys;
            gvHRFillingAssess.DataBind();
        }

        public CommandEventHandler hrFillingAssessCommand;
        protected void btnFillAssess_Command(object sender, CommandEventArgs e)
        {
            hrFillingAssessCommand(sender, e);
        }

        protected void gvHRFillingAssess_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessBasicInfoBack.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void gvHRFillingAssess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }
    }
}


    
