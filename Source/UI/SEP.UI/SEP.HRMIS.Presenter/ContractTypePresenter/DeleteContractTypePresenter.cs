//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteContractTypePresenter.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: ɾ����ͬ����С�����Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class DeleteContractTypePresenter
    {
        private readonly IContractType _ItsView;
        public IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();

        public DeleteContractTypePresenter(IContractType itsView)
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
            new ContractTypeIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = "ɾ����ͬ����";
            _ItsView.OperationType = "delete";
            _ItsView.SetReadonly = true;
            _ItsView.ActionButtonEnable = true;

            new ContractTypeDataBinder(_ItsView, _IContractTypeFacade).DataBind(id);

        }

        public void DeleteEvent()
        {
            try
            {
                _IContractTypeFacade.DeleteContractType(Convert.ToInt32(_ItsView.ContractTypeID));
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.ResultMessage = ae.Message;
            }
        }

        //for test
        public IContractTypeFacade IContractType
        {
            set { _IContractTypeFacade = value; }
        }
    }
}
