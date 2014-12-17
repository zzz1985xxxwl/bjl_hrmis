//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinListBack.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinListBack
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Bulletins;

namespace SEP.Performance.Pages.SEP.BulletinPages
{
    public partial class BulletinListBack : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new ListBulletinBackPresenter(userControlBulletinListBackView, IsPostBack, LoginUser);
        }
    }
}