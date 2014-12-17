//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: LeaveRequestTypeDataBinder.cs
// ������: ����
// ��������: 2008-10-07
// ����:�������С����������ռ���
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