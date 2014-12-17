//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: UpdateLeaveRequestTypePresenter.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述: 修改请假类型小界面的Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class UpdateLeaveRequestTypePresenter
    {
        private readonly ILeaveRequestTypeView _ItsView;
        public ILeaveRequestTypeFacade _LeaveRequestTypeBll = InstanceFactory.CreateLeaveRequestTypeFacade();

        public UpdateLeaveRequestTypePresenter(ILeaveRequestTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            new LeaveRequestTypeIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = LeaveRequestTypeUtility.UpdatePageTitle;
            _ItsView.ActionButtonTxt = LeaveRequestTypeUtility.UpdateActionButtonTxt;
            _ItsView.OperationType = LeaveRequestTypeUtility.UpdateOperationType;
            _ItsView.SetReadonly = false;
            _ItsView.SetIDReadonly = true;

            new LeaveRequestTypeDataBinder(_ItsView).DataBind(id);
        }

        public void UpdateEvent()
        {
            //数据验证过程
            if (!new LeaveRequestTypeVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            Model.Request.LeaveRequestType theObject =
                _LeaveRequestTypeBll.GetLeaveRequestTypeByPkid(Convert.ToInt32(_ItsView.LeaveRequestTypeID));
            new LeaveRequestTypeDataCollector(_ItsView).CompleteTheObject(ref theObject);
            try
            {
                _LeaveRequestTypeBll.UpdateLeaveRequestType(theObject);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}