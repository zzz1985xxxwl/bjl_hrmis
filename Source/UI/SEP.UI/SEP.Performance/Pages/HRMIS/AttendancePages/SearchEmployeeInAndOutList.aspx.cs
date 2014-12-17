//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SearchEmployeeInAndOutList.cs
// 创建者:刘丹
// 创建日期: 2008-10-29
// 概述: SearchEmployeeInAndOutList 列表 可新增修改删除查看详情
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class SearchEmployeeInAndOutList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A504))
            {
                throw new ApplicationException("没有权限访问");
            }
            new SearchEmployeeInAndOutInfoPresenter(PersonalInAndOutInfoView1, LoginUser).Initialize(IsPostBack);
        }
    }
}
