//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ContractTypeDataCollector.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: ��ͬ����С����������ռ���
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class ContractTypeDataCollector : IDataCollector<Model.ContractType>
    {
        private readonly IContractType _ItsView;

        public ContractTypeDataCollector(IContractType itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Model.ContractType theObjectToComplete)
        {
             if(theObjectToComplete != null)
             {
                 theObjectToComplete.ContractTypeName = _ItsView.ContractTypeName;
                 byte[] template = _ItsView.ContractTypeTemplate;
                 if (template!= null)
                 {
                     theObjectToComplete.ContractTemplate = template;
                 }
             }
        }

    }
}
