//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IFeedBackListView.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 培训反馈接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface IFeedBackListView
    {
        List<TrainEmployeeFB> employeeFBs { get;set;}

        bool SetScorcVisible { set;}

        bool SetFeedBackVisible { set;}

        bool SetIfFrontDetailPage { get; set;}

        event DelegateNoParameter DataBind;
    }
}
