//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SearchEmployeeInAndOutInfoPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-29
// 概述: 考勤信息综合界面Presenter
// ----------------------------------------------------------------

using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public class SearchEmployeeInAndOutInfoPresenter : PresenterCore.BasePresenter
    {
        private readonly IPersonalInAndOutInfoView _InfoView;
        private readonly SearchEmployeeInAndOutListPresenter _ListPresenter;

        public SearchEmployeeInAndOutInfoPresenter(IPersonalInAndOutInfoView infoView, Account loginUser)
            : base(loginUser)
        {
            _InfoView = infoView;

            _ListPresenter = new SearchEmployeeInAndOutListPresenter(_InfoView.InAndOutListView, loginUser);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        public override void Initialize(bool isPostBack)
        {
            _ListPresenter.InitView(isPostBack);
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

        private void AttachViewEvent()
        {
            //大界面按钮
            //note colbert 2
            //_InfoView.InAndOutListView.BtnAddEvent += ShowAddView;
            _InfoView.InAndOutListView.BtnUpdateEvent += ShowUpdateView;
            _InfoView.InAndOutListView.BtnDeleteEvent += ShowDeleteView;
            _InfoView.InAndOutListView.BtnDetailEvent += ShowDetailView;

            //小界面按钮
            _InfoView.InAndOutView.ActionButtonEvent += ActionEvent;
            _InfoView.InAndOutView.CancelButtonEvent += CancelEvent;
        }

        private void ShowUpdateView(string id)
        {
            string[] temp = id.Split(',');
            string employeeID = temp[0];
            _InfoView.InAndOutView.EmployeeId = employeeID;
            string recordId = temp[1];
            new PersonalInAndOutUpdatePresenter(_InfoView.InAndOutView, LoginUser).InitView(recordId);
            _InfoView.InAndOutViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            string[] temp = id.Split(',');
            string employeeID = temp[0];
            _InfoView.InAndOutView.EmployeeId = employeeID;
            string recordId = temp[1];
            new PersonalInAndOutDeletePresenter(_InfoView.InAndOutView, LoginUser).InitView(recordId);
            _InfoView.InAndOutViewVisible = true;
        }

        private void ShowDetailView(string id)
        {
            string[] temp = id.Split(',');
            string employeeID = temp[0];
            _InfoView.InAndOutView.EmployeeId = employeeID;
            string recordId = temp[1];
            new PersonalInAndOutDetailPresenter(_InfoView.InAndOutView, LoginUser).InitView(recordId);
            _InfoView.InAndOutViewVisible = true;
        }

        private void ActionEvent()
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

        private void CancelEvent()
        {
            _InfoView.InAndOutViewVisible = false;
        }
    }
}
