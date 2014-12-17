//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IBulletinShowDetailView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-19
// 概述: 增加IBulletinShowDetailView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Bulletins;

namespace SEP.Presenter.IPresenter.IBulletins
{
    public interface IBulletinShowDetailView
    {
        int BulletinID { get; set; }

        string Content { get; set; }

        string Title { get; set; }

        String PublishTime { get; set; }

        List<Appendix> AppendixList { get; set; }

        event EventHandler ShowBulletin;
    }
}