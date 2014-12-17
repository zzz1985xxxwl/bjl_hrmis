//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountBackVaildater.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 合同类型小界面的数据验证类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class ContractTypeVaildater : IVaildater
    {
        private readonly IContractType _ItsView;

        public ContractTypeVaildater(IContractType itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            if (String.IsNullOrEmpty(_ItsView.ContractTypeName.Trim()))
            {
                _ItsView.ValidateName = "合同类型名不能为空";
                return false;
            }
            if(!_ItsView.CheckFileType)
            {
                _ItsView.ResultMessage = "上传格式错误，请上传非空的word文档";
                return false;//为上传word做格式判断
            }
            else
            {
                _ItsView.ValidateName = string.Empty;
                return true;
            }
        }
    }
}
