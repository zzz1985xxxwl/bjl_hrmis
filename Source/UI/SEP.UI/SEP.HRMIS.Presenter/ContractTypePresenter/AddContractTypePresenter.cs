//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AddContractTypePresenter.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: ������ͬ����С�����Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class AddContractTypePresenter
    {
        private readonly IContractType _ItsView;
        public IContractTypeFacade _IContractTypeFacade;
        public ContractType _ANewObject;

        public AddContractTypePresenter(IContractType itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void InitView()
        {
            new ContractTypeIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = "������ͬ����";
            _ItsView.OperationType = "add";
            _ItsView.SetReadonly = false;
            _ItsView.ActionButtonEnable = true;
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void AddEvent()
        {
            //������֤
            if (!new ContractTypeVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //�����ռ�
            _ANewObject = new ContractType(0, "");
            new ContractTypeDataCollector(_ItsView).CompleteTheObject(_ANewObject);
            //ִ������
            try
            {
                _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
                _IContractTypeFacade.AddContractType(_ANewObject);
                _ItsView.ActionSuccess = true;
            }
            catch(ApplicationException ae)
            {
                _ItsView.ResultMessage = ae.Message;
            }

        }
    }
}
