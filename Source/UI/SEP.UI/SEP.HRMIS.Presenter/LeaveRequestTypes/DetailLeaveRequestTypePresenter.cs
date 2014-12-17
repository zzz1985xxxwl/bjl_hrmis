//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: DetailLeaveRequestTypePresenter.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述: 查看请假类型小界面的Presenter
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
   public class DetailLeaveRequestTypePresenter
    {
       private readonly ILeaveRequestTypeView _ItsView;
      
       public DetailLeaveRequestTypePresenter(ILeaveRequestTypeView itsView)
       {
           _ItsView = itsView;
           AttachViewEvent();
       }

       public void AttachViewEvent()
       {
           _ItsView.ActionButtonEvent += DetailEvent;
       }

       public void InitView(string id)
       {
           new LeaveRequestTypeIniter(_ItsView).InitTheViewToDefault();
           _ItsView.OperationTitle = LeaveRequestTypeUtility.DetailPageTitle;
           _ItsView.ActionButtonTxt = LeaveRequestTypeUtility.DetailActionButtonTxt;
           _ItsView.OperationType = LeaveRequestTypeUtility.DetailOperationType;
           _ItsView.SetReadonly = true;

           new LeaveRequestTypeDataBinder(_ItsView).DataBind(id);
       }

       public void DetailEvent()
       {
           _ItsView.ActionSuccess = true;
       }

    }
}
