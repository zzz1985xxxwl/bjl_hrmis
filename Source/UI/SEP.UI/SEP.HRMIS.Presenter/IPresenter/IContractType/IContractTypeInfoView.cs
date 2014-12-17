//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IContractTypeInfoView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 合同类型总界面的View要实现的接口
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType
{
    public interface IContractTypeInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        IContractTypeList ContractTypeListView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
        IContractType ContractTypeView { get;set;}
        /// <summary>
        /// 小界面可见
        /// </summary>
        bool ContractTypeViewVisible { get;set;}
    }
}
