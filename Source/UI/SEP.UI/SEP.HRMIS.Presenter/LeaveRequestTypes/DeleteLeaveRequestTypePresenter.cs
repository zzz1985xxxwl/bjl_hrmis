//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteLeaveRequestTypePresenter.cs
// ������: ����
// ��������: 2008-10-07
// ����: ɾ���������С�����Presenter
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
