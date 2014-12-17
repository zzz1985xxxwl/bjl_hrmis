//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IListBulletinForwardView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-18
// 概述: 增加IListBulletinForwardView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Bulletins;

namespace SEP.Presenter.IPresenter.IBulletins
{
    public  interface IListBulletinForwardView
    {
        List<Bulletin> BulletinList { get;set;}

        event EventHandler ShowBulletin;

    }
}
