//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeIniter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 合同类型小界面的界面初始化类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class ContractTypeIniter : IViewIniter
    {
        private readonly IContractType _ItsView;

        public ContractTypeIniter(IContractType itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.ContractTypeID = string.Empty;
            _ItsView.ContractTypeName = string.Empty;
            _ItsView.ValidateID = string.Empty;
            _ItsView.ValidateName = string.Empty;
            _ItsView.ResultMessage = string.Empty;
            _ItsView.Title = string.Empty;
        }

    }
}
