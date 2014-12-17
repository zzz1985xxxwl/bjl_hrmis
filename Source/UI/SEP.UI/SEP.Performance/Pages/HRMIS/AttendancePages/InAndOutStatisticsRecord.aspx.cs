//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InAndOutStatisticsRecord.cs
// 创建者: wangyueqi
// 创建日期: 2008-10-20
// 概述: InAndOutStatisticsRecord 列表
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics.AttendanceInAndOutStatistics;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class InAndOutStatisticsRecord : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PowerUser.UserHasPower(PowerUser._InAndOutStatisticsRecord);
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A503))
            {
                throw new ApplicationException("没有权限访问");
            }
            InAndOutStatisticsBuildView1.LoginUser = LoginUser;
            InAndOutStatisticsBuildPresenter inAndOutStatisticsBuildPresenter =
                new InAndOutStatisticsBuildPresenter(InAndOutStatisticsBuildView1, LoginUser);
            inAndOutStatisticsBuildPresenter.InitView(Page.IsPostBack);

        }
    }
}
