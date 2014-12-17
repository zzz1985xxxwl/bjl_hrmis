//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AddUpdateFamilyInfoPresenterBase.cs
// 创建者: 倪豪
// 创建日期: 2008-9-24
// 概述: 新增/修改家庭信息的Base类，将界面中与小界面相关的事件处理
//       单独抽出来做成该类，
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyMemberInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation
{
    public class AddUpdateFamilyInfoPresenterBase
    {
        protected readonly IFamilyInfoView _ItsView;

        public AddUpdateFamilyInfoPresenterBase(IFamilyInfoView itsView)
        {
            _ItsView = itsView;
            SwitchFamilyMemberPresenter();
            AttachViewEvent();
        }

        private void SwitchFamilyMemberPresenter()
        {
            if (string.IsNullOrEmpty(_ItsView.FamilyMemberView.Id))
            {
                new AddFamilyMemberPresenter(_ItsView.FamilyMemberView);
            }
            else
            {
                new UpdateFamilyMemberPresenter(_ItsView.FamilyMemberView, _ItsView.FamilyMemberView.Id);
            }
        }

        private void AttachViewEvent()
        {
            //家庭信息(大界面)
            _ItsView.FamilyBasicInfoView.BtnAddFamilyMemberEvent += BtnAddFamilyMemberEvent;
            _ItsView.FamilyBasicInfoView.BtnDeleteFamilyMemberEvent += BtnDeleteFamilyMemberEvent;
            _ItsView.FamilyBasicInfoView.BtnUpdateFamilyMemberEvent += BtnUpdateFamilyMemberEvent;
            //家庭信息(小界面)
            _ItsView.FamilyMemberView.BtnActionEvent += BtnActionEvent;
            _ItsView.FamilyMemberView.BtnCancelEvent += BtnCancelEvent;
        }

        private void BtnCancelEvent()
        {
            _ItsView.FamilyMemberViewVisiable = false;
        }

        private void BtnActionEvent()
        {
            if (_ItsView.FamilyMemberView.ActionSuccess)
            {
                _ItsView.FamilyBasicInfoView.FamilyMembersDataSource = _ItsView.FamilyMemberView.FamilyMemberDataSource;
                _ItsView.FamilyBasicInfoView.FamilyMembersView = _ItsView.FamilyBasicInfoView.FamilyMembersDataSource;                
                _ItsView.FamilyMemberViewVisiable = false;
            }
            else
            {
                _ItsView.FamilyMemberViewVisiable = true;
            }
        }

        private void BtnUpdateFamilyMemberEvent(string id)
        {
            new UpdateFamilyMemberPresenter(_ItsView.FamilyMemberView, id).InitView();
            _ItsView.FamilyMemberViewVisiable = true;
        }

        private void BtnDeleteFamilyMemberEvent(string id)
        {
            new DeleteFamilyMemberPresenter(_ItsView.FamilyMemberView).Delete(id);
            _ItsView.FamilyBasicInfoView.FamilyMembersDataSource = _ItsView.FamilyMemberView.FamilyMemberDataSource;
            _ItsView.FamilyBasicInfoView.FamilyMembersView = _ItsView.FamilyBasicInfoView.FamilyMembersDataSource;
        }

        public void BtnAddFamilyMemberEvent()
        {
            new AddFamilyMemberPresenter(_ItsView.FamilyMemberView).InitView();
            _ItsView.FamilyMemberViewVisiable = true;
        }
    }
}