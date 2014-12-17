//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeDataCollector.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 合同类型小界面的数据收集类
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
