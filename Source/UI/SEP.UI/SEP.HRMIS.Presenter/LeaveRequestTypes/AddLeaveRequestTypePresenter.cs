//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddLeaveRequestTypePresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class AddLeaveRequestTypePresenter
    {
        private readonly ILeaveRequestTypeView _ItsView;
        public ILeaveRequestTypeFacade _ItsTranscation=InstanceFactory.CreateLeaveRequestTypeFacade();
        public Model.Request.LeaveRequestType _ANewObject;

        public AddLeaveRequestTypePresenter(ILeaveRequestTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView()
        {
            new LeaveRequestTypeIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = LeaveRequestTypeUtility.AddPageTitle;
            _ItsView.ActionButtonTxt = LeaveRequestTypeUtility.AddActionButtonTxt;
            _ItsView.OperationType = LeaveRequestTypeUtility.AddOperationType;
            _ItsView.SetReadonly = false;
            _ItsView.SetIDReadonly = true;
        }

        public void AddEvent()
        {
            //数据验证过程
            if (!new LeaveRequestTypeVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            new LeaveRequestTypeDataCollector(_ItsView).CompleteTheObject(ref _ANewObject);
            try
            {
                _ItsTranscation.AddLeaveRequestType(_ANewObject);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}