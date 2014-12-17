//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AddContractTypePresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 新增合同类型小界面的Presenter
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
            _ItsView.Title = "新增合同类型";
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
            //数据验证
            if (!new ContractTypeVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集
            _ANewObject = new ContractType(0, "");
            new ContractTypeDataCollector(_ItsView).CompleteTheObject(_ANewObject);
            //执行事务
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
