//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: GetConfirmAssesses.cs
// 创建者: 顾艳娟
// 创建日期: 2008-06-17
// 概述: 确认考评活动
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AssessActivity;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class GetConfirmAssesses : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A704))
            {
                throw new ApplicationException("没有权限访问");
            }

            GetConfirmAssessesPresenter itsPresenter = new GetConfirmAssessesPresenter(GetConfirmAssessesView1, LoginUser);
            itsPresenter.Initialize(IsPostBack);
        }
    }
}
