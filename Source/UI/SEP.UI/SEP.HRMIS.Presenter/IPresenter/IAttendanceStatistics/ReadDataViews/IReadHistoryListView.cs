//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IReadHistoryListView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-16
// 概述: 读取数据的记录显示
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews
{
    public interface IReadHistoryListView
    {
        string Message { set;}

        string ErrorMessage { set;}
        /// <summary>
        /// 显示所有读取数据的记录
        /// </summary>
        List<ReadDataHistory> ReadHistorys{ set;}

        /// <summary>
        /// 读取事件
        /// </summary>
        event DelegateNoParameter BtnReadEvent;

        /// <summary>
        /// 绑定数据事件
        /// </summary>
        event DelegateNoParameter BindDataEvent;
        /// <summary>
        /// 取消
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;

        /// <summary>
        /// 读取是否成功
        /// </summary>
        bool IsReadSuccess { get; set;}

        string ReadFromTime { get;}

        string ReadToTime { get;}

        List<string> HoursSource{ set;}

        List<string> MinutesSource { set;}

    }
}
