// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IFeedBackBackSearchView.cs
// 创建者: 张燕
// 创建日期: 2008-11-14
// 概述: 查询培训反馈接口
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface IFeedBackBackSearchView
    {
        string ResultMessage { get;set;}

        string OperationMessage { get;set;}

        string TrainCourese { get; set;}

        string FBEmployee { get; set;}

        string FBTimeFrom { get; set;}

        string FBTimeTo { get; set;}

        string Status { get; set;}

        bool SetCourseName { set;}

        //  List<TrainEmployeeFB> FeedBackList { get; set;}

        IFeedBackListView listView { get; set;}

        //event DelegateNoParameter btnSearchClick;   





    }
}
