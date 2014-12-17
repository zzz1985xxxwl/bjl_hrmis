//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InAndOutDetailListView.cs
// 创建者:刘丹
// 创建日期: 2008-10-21
// 概述: InAndOutDetailListView 列表 可新增修改删除查看详情
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Presenter;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class InAndOutDetailListView : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonalInAndOutInfoPresenter presenter =
                new PersonalInAndOutInfoPresenter(PersonalInAndOutInfoView1,
                                                  SecurityUtil.DECDecrypt(Request.QueryString["employeeID"]), 
                                                  LoginUser);
            presenter.InitView(Page.IsPostBack, SecurityUtil.DECDecrypt(Request.QueryString["DepartmentID"]),
                               SecurityUtil.DECDecrypt(Request.QueryString["SearchFrom"]),
                               SecurityUtil.DECDecrypt(Request.QueryString["SearchTo"]));
        }
    }
}
