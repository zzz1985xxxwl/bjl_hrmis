//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IContractTypeListView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 合同类型大界面的View要实现的接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType
{
    public interface IContractTypeList
    {
        /// <summary>
        /// 合同类型数据源
        /// </summary>
        List<ContractType> ContractTypeSource { get;set;}
        ///// <summary>
        ///// 合同ID
        ///// </summary>
        //string ContractTypeID { get; set;}
        /// <summary>
        /// 合同名称
        /// </summary>
        string ContractTypeName { get; set;}
        /// <summary>
        /// 操作的消息
        /// </summary>
        string Message { get; set;}
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;        
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDetialEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        event DelegateReturnByte BtnDownLordEvent;

    }
}
