//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: LeaveRequestTypeDataBinder.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述:请假类型小界面的数据收集类
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class LeaveRequestTypeDataCollector
    {
        private readonly ILeaveRequestTypeView _ItsView;

        public LeaveRequestTypeDataCollector(ILeaveRequestTypeView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(ref Model.Request.LeaveRequestType theObjectToComplete)
        {
            int leaveRequestTypeID = string.IsNullOrEmpty(_ItsView.LeaveRequestTypeID)
                                         ? 0
                                         : Convert.ToInt32(_ItsView.LeaveRequestTypeID);
            theObjectToComplete = new Model.Request.LeaveRequestType
                (leaveRequestTypeID, _ItsView.LeaveRequestTypeName, _ItsView.LeaveRequestTypeDescription,
                _ItsView.IncludeLegalHoliday,_ItsView.IncludeRestDay, Convert.ToDecimal(_ItsView.LeastHour));
        }
    }
}