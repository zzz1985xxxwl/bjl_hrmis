//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypePresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-06
// 概述: 合同类型总界面
// ----------------------------------------------------------------


using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class ContractTypePresenter 
    {
        private readonly IContractTypeInfoView _ItsView;
        private readonly ListContractTypePresenter _TheBasicPresenter;
        public IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        public ContractTypePresenter(IContractTypeInfoView itsView)
        {
            _ItsView = itsView;
            _TheBasicPresenter = new ListContractTypePresenter(itsView.ContractTypeListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.ContractTypeView.OperationType)
            {
                case "add":
                    new AddContractTypePresenter(_ItsView.ContractTypeView);
                    break;
                case "update":
                    new UpdateContractTypePresenter(_ItsView.ContractTypeView);
                    break;
                case "delete":
                    new DeleteContractTypePresenter(_ItsView.ContractTypeView);
                    break;
                case "detail":
                    new DetailContractTypePresenter(_ItsView.ContractTypeView);
                    break;
            }
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.ContractTypeListView.BtnAddEvent += ShowAddView;
            _ItsView.ContractTypeListView.BtnUpdateEvent += ShowUpdateView;
            _ItsView.ContractTypeListView.BtnDeleteEvent += ShowDeleteView;
            _ItsView.ContractTypeListView.BtnDetialEvent += ShowDetialView;
            _ItsView.ContractTypeListView.BtnDownLordEvent += DownLordEvent;
            //_ItsView.ContractTypeListView.BtnSearchEvent += ShowSearchView;

            //小界面按钮
            _ItsView.ContractTypeView.ActionButtonEvent += ActionEvent;
            _ItsView.ContractTypeView.CancelButtonEvent += CancelEvent;
        }
        private byte[] DownLordEvent(int id)
        {
            ContractType contractType = _IContractTypeFacade.GetContractTypeByPKID(id);
            return contractType.ContractTemplate;
        }

        private void ShowAddView()
        {
            new AddContractTypePresenter(_ItsView.ContractTypeView).InitView();
            _ItsView.ContractTypeViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new UpdateContractTypePresenter(_ItsView.ContractTypeView).InitView(id);
            _ItsView.ContractTypeViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            new DeleteContractTypePresenter(_ItsView.ContractTypeView).InitView(id);
            _ItsView.ContractTypeViewVisible = true;
        }

        private void ShowDetialView(string id)
        {
            new DetailContractTypePresenter(_ItsView.ContractTypeView).InitView(id);
            _ItsView.ContractTypeViewVisible = true;
        }

        
        //private void ShowSearchView()
        //{
        //    new ListContractTypePresenter(_ItsView.ContractTypeListView).ShowSearchView();
        //    _ItsView.ContractTypeViewVisible = false;
        //}

        public void InitView(bool pageIsPostBack)
        {
            _TheBasicPresenter.InitView(pageIsPostBack);
        }

        private void ActionEvent()
        {
            if(_ItsView.ContractTypeView.ActionSuccess)
            {
                _TheBasicPresenter.ShowSearchView();
                _ItsView.ContractTypeViewVisible = false; 
            }
            else
            {
                _ItsView.ContractTypeViewVisible = true;
            }
        }

        private void CancelEvent()
        {
            _ItsView.ContractTypeViewVisible = false;
        }

    }
}
