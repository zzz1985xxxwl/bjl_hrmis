//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: LeaveRequestTypeDataBinder.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述:请假类型小界面的数据绑定类
// ----------------------------------------------------------------


using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
   public class LeaveRequestTypeDataBinder
    {
       public ILeaveRequestTypeFacade _LeaveRequestTypeBll = InstanceFactory.CreateLeaveRequestTypeFacade();
       private readonly ILeaveRequestTypeView _ItsView;

       public LeaveRequestTypeDataBinder(ILeaveRequestTypeView itsView)
        {
            _ItsView = itsView;
        }

       public void DataBind(string leaveRequestTypeId)
        {
            Model.Request.LeaveRequestType theDataToBind = _LeaveRequestTypeBll.GetLeaveRequestTypeByPkid(Convert.ToInt32(leaveRequestTypeId));
            if (theDataToBind != null)
            {
                _ItsView.LeaveRequestTypeID = theDataToBind.LeaveRequestTypeID.ToString();
                _ItsView.LeaveRequestTypeName = theDataToBind.Name;
                _ItsView.LeaveRequestTypeDescription = theDataToBind.Description;
                _ItsView.IncludeLegalHoliday = theDataToBind.IncludeLegalHoliday;
                _ItsView.IncludeRestDay = theDataToBind.IncludeRestDay;
                _ItsView.LeastHour = theDataToBind.LeastHour.ToString();
            }
        }

    }
}
