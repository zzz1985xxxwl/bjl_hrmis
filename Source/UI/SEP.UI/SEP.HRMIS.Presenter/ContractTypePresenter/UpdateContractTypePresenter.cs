//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: UpdateContractTypePresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 修改合同类型小界面的Presenter
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
            _ItsView.Title = "修改合同类型";
            _ItsView.OperationType = "update";
            _ItsView.SetReadonly = false;
            _ItsView.ActionButtonEnable = true;
            
            new ContractTypeDataBinder(_ItsView, _IContractTypeFacade).DataBind(id);
        }

        public void UpdateEvent()
        {
            //数据验证过程
            if (!new ContractTypeVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            Model.ContractType theObject = _IContractTypeFacade.GetContractTypeByPKID(Convert.ToInt32(_ItsView.ContractTypeID));
            new ContractTypeDataCollector(_ItsView).CompleteTheObject(theObject);
            //执行事务过程
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
