//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IShowDetailView.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-27
// 概述: 接口
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics
{
    public interface IShowDetailView
    {
        string Employee { get;set;}
        string Type { get;set;}
        string Time { get;set;}
        string Date { get;set;}
        string Location { get;set;}
        string Reason { get;set;}
   }
}
