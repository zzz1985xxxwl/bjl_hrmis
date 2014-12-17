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

namespace SEP.HRMIS.Presenter
{
    public class PersonalInAndOutInfoPresenter : PresenterCore.BasePresenter
    {
        private readonly IPersonalInAndOutInfoView _InfoView;
        private readonly PersonalInAndOutListPresenter _ListPresenter;

        public PersonalInAndOutInfoPresenter(IPersonalInAndOutInfoView infoView, string employeeId, Account loginUser)
            : base(loginUser)
        {
            _InfoView = infoView;

            _InfoView.InAndOutView.EmployeeId = employeeId;
            _ListPresenter = new PersonalInAndOutListPresenter(_InfoView.InAndOutListView, loginUser);
            _InfoView.InAndOutListView.EmployeeId = employeeId;
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_InfoView.InAndOutView.OperationType)
            {
                case "Add":
                    new PersonalInAndOutAddPresenter(_InfoView.InAndOutView, LoginUser);
                    break;
                case "Update":
                    new PersonalInAndOutUpdatePresenter(_InfoView.InAndOutView, LoginUser);
                    break;
                case "Delete":
                    new PersonalInAndOutDeletePresenter(_InfoView.InAndOutView, LoginUser);
                    break;
                case "Detail":
                    new PersonalInAndOutDetailPresenter(_InfoView.InAndOutView, LoginUser);
                    break;

            }
        }

        public void AttachViewEvent()
        {
            //����水ť
            _InfoView.InAndOutListView.BtnAddEvent += ShowAddView;
            _InfoView.InAndOutListView.BtnUpdateEvent += ShowUpdateView;
            _InfoView.InAndOutListView.BtnDeleteEvent += ShowDeleteView;
            _InfoView.InAndOutListView.BtnDetailEvent += ShowDetailView;

            //С���水ť
            _InfoView.InAndOutView.ActionButtonEvent += ActionEvent;
            _InfoView.InAndOutView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new PersonalInAndOutAddPresenter(_InfoView.InAndOutView, LoginUser).InitView();
            _InfoView.InAndOutViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new PersonalInAndOutUpdatePresenter(_InfoView.InAndOutView, LoginUser).InitView(id);
            _InfoView.InAndOutViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            new PersonalInAndOutDeletePresenter(_InfoView.InAndOutView, LoginUser).InitView(id);
            _InfoView.InAndOutViewVisible = true;
        }

        private void ShowDetailView(string id)
        {
            new PersonalInAndOutDetailPresenter(_InfoView.InAndOutView, LoginUser).InitView(id);
            _InfoView.InAndOutViewVisible = true;
        }

        public void ActionEvent()
        {
            if (_InfoView.InAndOutView.ActionSuccess)
            {
                _ListPresenter.DataBind();
                _InfoView.InAndOutViewVisible = false;
            }
            else
            {
                _InfoView.InAndOutViewVisible = true;
            }
        }

        public void CancelEvent()
        {
            _InfoView.InAndOutViewVisible = false;
        }

        public void InitView(bool pageIsPostBack, string dempartmentId, string searchFrom, string searchTo)
        {
            if (!pageIsPostBack)
            {
                _InfoView.InAndOutListView.Department = Convert.ToInt32(dempartmentId);
                _InfoView.InAndOutListView.TempTimeFrom = searchFrom;
                _InfoView.InAndOutListView.TempTimeTo = searchTo;
            }
            _ListPresenter.Initialize(pageIsPostBack);
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
