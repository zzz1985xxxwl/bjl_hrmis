//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinAdd.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinAdd
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Bulletins;

namespace SEP.Performance.Pages.SEP.BulletinPages
{
    public partial class BulletinAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddBulletinPresenter presenter = new AddBulletinPresenter(userControlEditBulletinView, LoginUser);
            userControlEditBulletinView.OpetaTitle = "新增公告";
            presenter._AddBulletinCompleteEvent += HandleAddBulletinCompleteEvent;
        }

        private void HandleAddBulletinCompleteEvent(object sender, EventArgs e)
        {
            Response.Redirect("BulletinListBack.aspx", false);
        }
    }
}