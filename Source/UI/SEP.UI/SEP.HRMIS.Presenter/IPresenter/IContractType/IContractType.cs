//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IContractTypeView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 合同类型小界面的View要实现的接口
// ----------------------------------------------------------------
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType
{
    public interface IContractType
    {
        /// <summary>
        /// 合同类型ID
        /// </summary>
        string ContractTypeID { get; set; }
        /// <summary>
        /// 合同类型名称
        /// </summary>
        string ContractTypeName { get; set; }
        /// <summary>
        /// 合同模板
        /// </summary>
        byte[] ContractTypeTemplate{ get;}
        /// <summary>
        /// 合同类型名称的消息
        /// </summary>
        string ResultMessage { get;set; }
        /// <summary>
        /// 合同类型ID是否有效
        /// </summary>
        string ValidateID { get; set; }
        /// <summary>
        /// 合同类型名称是否有效
        /// </summary>
        string ValidateName { get; set; }
        /// <summary>
        /// 是否只读
        /// </summary>
        bool SetReadonly { get; set; }
        /// <summary>
        /// 小界面标题
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// 确认按钮是否可用
        /// </summary>
        bool ActionButtonEnable { get; set;}

         /// <summary>
        /// 判断上传类型
        /// </summary>
        bool CheckFileType{ get; set;}
        //event EventHandler btnOKClick;
        //event EventHandler btnCancelServerClick;
    }
}
