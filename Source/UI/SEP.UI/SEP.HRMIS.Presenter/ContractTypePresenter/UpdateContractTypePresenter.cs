//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateContractTypePresenter.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: �޸ĺ�ͬ����С�����Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class UpdateContractTypePresenter
    {
        private readonly IContractType _ItsView;
        public IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();

        public UpdateContractTypePresenter(IContractType itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            new ContractTypeIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = "�޸ĺ�ͬ����";
            _ItsView.OperationType = "update";
            _ItsView.SetReadonly = false;
            _ItsView.ActionButtonEnable = true;
            
            new ContractTypeDataBinder(_ItsView, _IContractTypeFacade).DataBind(id);
        }

        public void UpdateEvent()
        {
            //������֤����
            if (!new ContractTypeVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //�����ռ�����
            Model.ContractType theObject = _IContractTypeFacade.GetContractTypeByPKID(Convert.ToInt32(_ItsView.ContractTypeID));
            new ContractTypeDataCollector(_ItsView).CompleteTheObject(theObject);
            //ִ���������
            try
            {
                _IContractTypeFacade.UpdateContractType(theObject);
                _ItsView.ActionSuccess = true;
            }
            catch(ApplicationException ae)
            {
                _ItsView.ResultMessage = ae.Message;
            }
        }

        //for test
        public IContractTypeFacade ContractTypeSource
        {
            set { _IContractTypeFacade = value; }
        }
    }
}
