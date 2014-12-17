//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: LeaveRequestTypeDataBinder.cs
// ������: ����
// ��������: 2008-10-07
// ����:������ʹ����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class LeaveRequestTypeListPresenter 
    {
        private readonly ILeaveRequestTypeListView _ItsView;
        public ILeaveRequestTypeFacade _LeaveRequestTypeBll = InstanceFactory.CreateLeaveRequestTypeFacade();

        public LeaveRequestTypeListPresenter(ILeaveRequestTypeListView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
    
        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                LeaveRequestTypeDataBind();
            }
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += LeaveRequestTypeDataBind;
        }

        public void LeaveRequestTypeDataBind()
        {
            List<Model.Request.LeaveRequestType> itsSource = _LeaveRequestTypeBll.GetLeaveRequestTypeByNameLike(_ItsView.LeaveRequestTypeName);
            _ItsView.LeaveRequestTypes = itsSource;
        }


    }
}
