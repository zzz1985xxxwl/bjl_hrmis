//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AddUpdateFamilyInfoPresenterBase.cs
// ������: �ߺ�
// ��������: 2008-9-24
// ����: ����/�޸ļ�ͥ��Ϣ��Base�࣬����������С������ص��¼�����
//       ������������ɸ��࣬
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
            //��ͥ��Ϣ(�����)
            _ItsView.FamilyBasicInfoView.BtnAddFamilyMemberEvent += BtnAddFamilyMemberEvent;
            _ItsView.FamilyBasicInfoView.BtnDeleteFamilyMemberEvent += BtnDeleteFamilyMemberEvent;
            _ItsView.FamilyBasicInfoView.BtnUpdateFamilyMemberEvent += BtnUpdateFamilyMemberEvent;
            //��ͥ��Ϣ(С����)
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