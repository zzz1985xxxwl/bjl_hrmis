//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ConfirmAssess.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-16
// 概述: 添加确认考评活动
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.AssessActivity;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class ConfirmAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessBasicInfoPresenter assessBasicInfoPresenter =
                new AssessBasicInfoPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                             AssessBasicInfoView1, false, LoginUser);
            assessBasicInfoPresenter.Initialize(IsPostBack);
            ConfirmAssessPresenter presenter =
                new ConfirmAssessPresenter(SecurityUtil.DECDecrypt(Request.QueryString["assessActivityID"]),
                                           ConfirmAssessView1, LoginUser);
            ConfirmAssessView1.btnConfirmClick += presenter.btnConfirmClick;
            presenter.ToFillAssessPage += ToFillAssessPage;
            presenter.Initialize(IsPostBack);
        }

        private void ToFillAssessPage(object sender, EventArgs e)
        {
            string href = Convert.ToString(sender);
            if (href.EndsWith("?"))
            {
                Response.Redirect(href + ConstParameters.AssessActivityID + "=" +
                                  Request.QueryString["assessActivityID"] + "&submitID=" +
                                  SecurityUtil.DECEncrypt(ConfirmAssessView1.SubmitID), false);
            }
            else
            {
                Response.Redirect(href);
            }
        }
    }
}
