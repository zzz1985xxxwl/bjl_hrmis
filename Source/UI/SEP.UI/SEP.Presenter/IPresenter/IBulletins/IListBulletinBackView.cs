//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IListBulletinBackView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-18
// 概述: 增加IListBulletinBackView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Bulletins;
using SEP.Model.Departments;

namespace SEP.Presenter.IPresenter.IBulletins
{
    public interface IListBulletinBackView
    {
        List<Bulletin> BulletinList { get; set; }

        string Title { get; set; }

        string PublishStartTime { get; set; }

        string PublishEndTime { get; set; }

        List<Department> DepartmentSource { set; }

        int DepartmentId { get; }

        string Message { get; set; }

        int BulletinID { get; set; }

        event EventHandler btnSearchClicked;

        event EventHandler DeleteBulletin;
    }
}