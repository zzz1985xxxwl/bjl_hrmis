//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ApplicationSearch.cs
// 创建者: wangyueqi
// 创建日期: 2009-6-1
// 概述: ApplicationSearch 列表
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class ApplicationSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A509))
            {
                throw new ApplicationException("没有权限访问");
            }
            ApplicationSearchPresenter applicationSearchPresenter =
                new ApplicationSearchPresenter(ApplicationSearchView1, LoginUser);
            applicationSearchPresenter.Initialize(Page.IsPostBack);
            ApplicationSearchView1.btnViewClick += ToDetailPage;

        }
        public void ToDetailPage(string info)
        {
            string id=info.Split(';')[0];
            string type = info.Split(';')[1];
            switch(type)
            {
                case "Leave":
                    Response.Redirect("../LeaveRequestPages/LeaveRequestDetail.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(id), false);
                    break;
                case "Out":
                    Response.Redirect("../OutApplicationPages/OutApplicationDetail.aspx?PKID=" + SecurityUtil.DECEncrypt(id), false);
                    break;
                case "OverWork":
                    Response.Redirect("../OverWorkPages/OverWorkDetail.aspx?PKID=" + SecurityUtil.DECEncrypt(id), false);
                    break;
                default:
                    break;
            }

        }
    }
}
