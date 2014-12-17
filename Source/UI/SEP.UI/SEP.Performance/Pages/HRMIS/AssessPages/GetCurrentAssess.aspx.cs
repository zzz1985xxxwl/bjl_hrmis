//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: GetCurrentAssess.aspx.cs
// 创建者: 倪豪
// 创建日期: 2008-06-23
// 概述: 获取当前登录人所有待填写的考评活动
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.AssessActivity;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class GetCurrentAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCurrentAssessPresenter itsPresenter = new GetCurrentAssessPresenter(GetCurrentAssess1, LoginUser);
            itsPresenter.Initialize(IsPostBack);
        }
    }
}
