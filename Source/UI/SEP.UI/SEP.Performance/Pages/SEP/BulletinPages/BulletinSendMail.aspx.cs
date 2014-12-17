//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinSendMail.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinSendMail
// ----------------------------------------------------------------
using System;
using SEP.Presenter;

namespace SEP.Performance.Pages.SEP.BulletinPages
{
    public partial class BulletinSendMail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new SendMailForBulletinPresenter(userControlBulletinSendMailView,LoginUser);       
        }
    }
}
