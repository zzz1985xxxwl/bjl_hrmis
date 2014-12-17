//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ILeaveRequestTypeInfoView.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述: 请假类型的总界面的View要实现的接口
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType
{
  public interface ILeaveRequestTypeInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
      ILeaveRequestTypeListView LeaveRequestTypeListView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
      ILeaveRequestTypeView LeaveRequestTypeView { get;set;}
        /// <summary>
        /// 小界面可见
        /// </summary>
      bool LeaveRequestTypeViewVisible { get;set;}
    }
}
