//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IUpdateBulletinView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-05
// 概述: 增加IUpdateBulletinView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Bulletins;
using SEP.Model.Departments;

namespace SEP.Presenter.IPresenter.IBulletins
{
    public interface IEditBulletinView
    {
        List<Appendix> AppendixList { get; set; }

        int BulletinID { get; set; }

        string Content { get; set; }

        string Title { get; set; }

        String PublishTime { get; set; }

        int AppendixID { get; set; }

        string ATitle { get; set; }

        string Directory { get; set; }

        string lblBulletinTitleMessage { get; set; }

        string lblPublishTimeMessage { get; set; }

        string lblAppendixListMessage { get; set; }

        string ErrorMessageFromBll { get; set; }

        List<Department> DepartmentSource{  set;}

        int DepartmentId { get; set;}

        event EventHandler btnOKClicked;

        event EventHandler DeleteAppendix;

        event EventHandler AddAppendix;

        event EventHandler InitView;
    }
}