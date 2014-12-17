//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalInAndOutInfoPresenter.cs
// ������: ����
// ��������: 2008-10-21
// ����: ������Ϣ�ۺϽ���Presenter
// ----------------------------------------------------------------
using System;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;

namespace SEP.HRMIS.Presenter
{
    public class CompanyLinkManInfoPresenter : PresenterCore.BasePresenter
    {
        private readonly ICompanyLinkManInfoView _InfoView;
        private readonly CompanyLinkManListPresenter _ListPresenter;

        public CompanyLinkManInfoPresenter(ICompanyLinkManInfoView infoView, Account loginUser)
            : base(loginUser)
        {
            _InfoView = infoView;
            _ListPresenter = new CompanyLinkManListPresenter(_InfoView.LinkManListView, loginUser);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_InfoView.LinkManView.OperationType)
            {
                case "Add":
                    new CompanyLinkManAddPresenter(_InfoView.LinkManView, LoginUser);
                    break;
                case "Update":
                    new CompanyLinkManUpdatePresenter(_InfoView.LinkManView, LoginUser);
                    break;
                case "Delete":
                    new CompanyLinkManDeletePresenter(_InfoView.LinkManView, LoginUser);
                    break;
                case "Detail":
                    new CompanyLinkManDetailPresenter(_InfoView.LinkManView, LoginUser);
                    break;

            }
        }

        public void AttachViewEvent()
        {
            //����水ť
            _InfoView.LinkManListView.BtnAddEvent += ShowAddView;
            _InfoView.LinkManListView.BtnUpdateEvent += ShowUpdateView;
            _InfoView.LinkManListView.BtnDeleteEvent += ShowDeleteView;
            _InfoView.LinkManListView.BtnDetailEvent += ShowDetailView;

            //С���水ť
            _InfoView.LinkManView.ActionButtonEvent += ActionEvent;
            _InfoView.LinkManView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new CompanyLinkManAddPresenter(_InfoView.LinkManView, LoginUser).InitView();
            _InfoView.LinkManViewVisible = true;
        }

        private void ShowUpdateView(Guid id)
        {
            new CompanyLinkManUpdatePresenter(_InfoView.LinkManView, LoginUser).InitView(id);
            _InfoView.LinkManViewVisible = true;
        }

        private void ShowDeleteView(Guid id)
        {
            new CompanyLinkManDeletePresenter(_InfoView.LinkManView, LoginUser).InitView(id);
            _InfoView.LinkManViewVisible = true;
        }

        private void ShowDetailView(Guid id)
        {
            new CompanyLinkManDetailPresenter(_InfoView.LinkManView, LoginUser).InitView(id);
            _InfoView.LinkManViewVisible = true;
        }

        public void ActionEvent()
        {
            if (_InfoView.LinkManView.ActionSuccess)
            {
                _ListPresenter.DataBind();
                _InfoView.LinkManViewVisible = false;
            }
            else
            {
                _InfoView.LinkManViewVisible = true;
            }
        }

        public void CancelEvent()
        {
            _InfoView.LinkManViewVisible = false;
        }

        public void InitView(bool pageIsPostBack)
        {
            _ListPresenter.Initialize(pageIsPostBack);
        }

        public override void Initialize(bool isPostBack)
        {
        }
    }
}
