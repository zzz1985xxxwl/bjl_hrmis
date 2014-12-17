//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights BulletinShowDetailBack.
// 文件名: BulletinSendMail.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinShowDetailBack
// ----------------------------------------------------------------

using System;
using SEP.Presenter.Bulletins;

namespace SEP.Performance.Pages.SEP.BulletinPages
{
    public partial class BulletinShowDetailBack : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new BulletinShowDetailPresenter(userControlBulletinShowDetailView, LoginUser);

            userControlBulletinShowDetailView.GoBack += GoBack;        
        }
        private void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("BulletinListBack.aspx",false);
        }
    }
}
