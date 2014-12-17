//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinListForward.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-19
// 概述: 增加BulletinListForward
// ----------------------------------------------------------------
using System;
using SEP.Presenter.Bulletins;

namespace SEP.Performance.Pages.SEP.BulletinPages
{
    public partial class BulletinListForward : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           ListBulletinForwardPresenter present= new ListBulletinForwardPresenter(userControlBulletinListForwardView, LoginUser);
           userControlBulletinListForwardView.ShowBulletin += present.SearchBulletin;
        }
    }
}
