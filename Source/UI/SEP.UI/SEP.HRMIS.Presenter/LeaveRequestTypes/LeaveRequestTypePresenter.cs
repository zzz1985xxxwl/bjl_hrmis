//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: LeaveRequestTypeDataBinder.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述:请假类型总界面
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class LeaveRequestTypePresenter
    {
        private readonly ILeaveRequestTypeInfoView _ItsView;
        private readonly LeaveRequestTypeListPresenter _TheBasicPresenter;

        public LeaveRequestTypePresenter(ILeaveRequestTypeInfoView itsView)
        {
            _ItsView = itsView;
            _TheBasicPresenter = new LeaveRequestTypeListPresenter(itsView.LeaveRequestTypeListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.LeaveRequestTypeView.OperationType)
            {
                case "Add":
                    new AddLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView);
                    break;
                case "Update":
                    new UpdateLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView);
                    break;
                case "Delete":
                    new DeleteLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView);
                    break;
                case "Detail":
                    new DetailLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView);
                    break;
            }
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.LeaveRequestTypeListView.BtnAddEvent += ShowAddView;
            _ItsView.LeaveRequestTypeListView.BtnUpdateEvent += ShowUpdateView;
            _ItsView.LeaveRequestTypeListView.BtnDeleteEvent += ShowDeleteView;
            _ItsView.LeaveRequestTypeListView.BtnDetailEvent += ShowDetailView;
            //_ItsView.LeaveRequestTypeListView.BtnSearchEvent += ShowSearchView;
            //小界面按钮
            _ItsView.LeaveRequestTypeView.ActionButtonEvent += ActionEvent;
            _ItsView.LeaveRequestTypeView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new AddLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView).InitView();
            _ItsView.LeaveRequestTypeViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new UpdateLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView).InitView(id);
            _ItsView.LeaveRequestTypeViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            new DeleteLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView).InitView(id);
            _ItsView.LeaveRequestTypeViewVisible = true;
        }

        private void ShowDetailView(string id)
        {
            new DetailLeaveRequestTypePresenter(_ItsView.LeaveRequestTypeView).InitView(id);
            _ItsView.LeaveRequestTypeViewVisible = true;
        }

        private void ShowSearchView()
        {
            new LeaveRequestTypeListPresenter(_ItsView.LeaveRequestTypeListView).LeaveRequestTypeDataBind();
            _ItsView.LeaveRequestTypeViewVisible = false;
        }

        public void ActionEvent()
        {
            if (_ItsView.LeaveRequestTypeView.ActionSuccess)
            {
                _TheBasicPresenter.LeaveRequestTypeDataBind();
                _ItsView.LeaveRequestTypeViewVisible = false;
            }
            else
            {
                _ItsView.LeaveRequestTypeViewVisible = true;
            }
        }

        public void CancelEvent()
        {
            _ItsView.LeaveRequestTypeViewVisible = false;
        }

        public void InitView(bool pageIsPostBack)
        {
            _TheBasicPresenter.InitView(pageIsPostBack);
        }
    }
}