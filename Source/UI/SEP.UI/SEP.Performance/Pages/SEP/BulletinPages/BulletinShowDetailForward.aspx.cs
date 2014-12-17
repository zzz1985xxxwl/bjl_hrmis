//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinShowDetail.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinShowDetail
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Bulletins;

namespace SEP.Performance.Pages.SEP.BulletinPages
{
    public partial class BulletinShowDetailForward : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new BulletinShowDetailPresenter(userControlBulletinShowDetailView, LoginUser);
            userControlBulletinShowDetailView.GoBack += GoBack;
        }

        private void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("BulletinListForward.aspx", false);
        }
    }
}