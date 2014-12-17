//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CustomerInfoPresenter.cs
// 创建者: 刘丹
// 创建日期: 2009-08-17
// 概述: 总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo;

namespace SEP.HRMIS.Presenter.Parameter.CustomerInfos
{
   public  class CustomerInfoPresenter
    {
       private readonly ICustomerInfoAllView _InfoView;
       private readonly CustomerInfoListPresenter _ListPresenter;

       public CustomerInfoPresenter(ICustomerInfoAllView infoView)
        {
            _InfoView = infoView;
            _ListPresenter = new CustomerInfoListPresenter(_InfoView.CustomerInfoListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_InfoView.CustomerInfoView.OperationType)
            {
                case "Add":
                    new AddCustomerInfoPresenter(_InfoView.CustomerInfoView);
                    break;
                case "Update":
                    new UpdateCustomerInfoPresenter(_InfoView.CustomerInfoView);
                    break;
                case "Delete":
                    new DeleteCustomerInfoPresenter(_InfoView.CustomerInfoView);
                    break;

            }
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _InfoView.CustomerInfoListView.BtnAddEvent += ShowAddView;
            _InfoView.CustomerInfoListView.BtnUpdateEvent += ShowUpdateView;
            _InfoView.CustomerInfoListView.BtnDeleteEvent += ShowDeleteView;

            //小界面按钮
            _InfoView.CustomerInfoView.ActionButtonEvent += ActionEvent;
            _InfoView.CustomerInfoView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new AddCustomerInfoPresenter(_InfoView.CustomerInfoView).InitView();
            _InfoView.ShowCustomerInfoViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new UpdateCustomerInfoPresenter(_InfoView.CustomerInfoView).InitView(id);
            _InfoView.ShowCustomerInfoViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            new DeleteCustomerInfoPresenter(_InfoView.CustomerInfoView).InitView(id);
            _InfoView.ShowCustomerInfoViewVisible = true;
        }

        public void ActionEvent()
        {
            if (_InfoView.CustomerInfoView.ActionSuccess)
            {
                _ListPresenter.SearchEvent();
                _InfoView.ShowCustomerInfoViewVisible = false;
            }
            else
            {
                _InfoView.ShowCustomerInfoViewVisible = true;
            }
        }

        public void CancelEvent()
        {
            _InfoView.ShowCustomerInfoViewVisible = false;
        }

        public void InitView(bool pageIsPostBack)
        {
            _ListPresenter.InitView(pageIsPostBack);
        }

    }
}
