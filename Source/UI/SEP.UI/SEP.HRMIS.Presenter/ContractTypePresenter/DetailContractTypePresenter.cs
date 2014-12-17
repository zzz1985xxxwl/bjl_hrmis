//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: DetailContractTypePresenter.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: �鿴��ͬ������ϸ��ϢС�����Presenter
// ----------------------------------------------------------------


using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class DetailContractTypePresenter
    {
        private readonly IContractType _ItsView;
        public IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();

        public DetailContractTypePresenter(IContractType itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(string id)
        {
            new ContractTypeIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = "��ͬ��������";
            _ItsView.OperationType = "detial";
            _ItsView.SetReadonly = true;
            _ItsView.ActionButtonEnable = false;

            new ContractTypeDataBinder(_ItsView, _IContractTypeFacade).DataBind(id);
        }


    }
}
