//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinUpdate.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinUpdate
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.Presenter.Bulletins;

namespace SEP.Performance.Pages.SEP.BulletinPages
{
    public partial class BulletinUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateBulletinPresenter presenter = new UpdateBulletinPresenter(userControlEditBulletinView, LoginUser);
            userControlEditBulletinView.OpetaTitle = "修改公告";
            presenter._UpdateCustomerCompleteEvent += (HandleUpdateBulletinCompleteEvent);
        }

        private void HandleUpdateBulletinCompleteEvent(object sender, EventArgs e)
        {
            Response.Redirect("BulletinListBack.aspx", false);
        }
    }
}