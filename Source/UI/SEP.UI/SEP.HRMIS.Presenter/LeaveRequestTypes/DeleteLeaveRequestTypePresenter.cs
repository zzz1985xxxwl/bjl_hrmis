//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: DeleteLeaveRequestTypePresenter.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述: 删除请假类型小界面的Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class DeleteLeaveRequestTypePresenter
    {
        private readonly ILeaveRequestTypeView _ItsView;
        public ILeaveRequestTypeFacade _LeaveRequestTypeBll = InstanceFactory.CreateLeaveRequestTypeFacade();
        public DeleteLeaveRequestTypePresenter(ILeaveRequestTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DeleteEvent;
        }

        public void InitView(string id)
        {
            new LeaveRequestTypeIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = LeaveRequestTypeUtility.DeletePageTitle;
            _ItsView.ActionButtonTxt = LeaveRequestTypeUtility.DeleteActionButtonTxt;
            _ItsView.OperationType = LeaveRequestTypeUtility.DeleteOperationType;
            _ItsView.SetReadonly = true;

            new LeaveRequestTypeDataBinder(_ItsView).DataBind(id);
        }

        private void DeleteEvent()
        {
            try
            {
                _LeaveRequestTypeBll.DeleteLeaveRequestType(Convert.ToInt32(_ItsView.LeaveRequestTypeID));
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}
