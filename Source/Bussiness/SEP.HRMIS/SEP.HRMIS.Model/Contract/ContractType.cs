//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractType.cs
// 创建者: 薛文龙
// 创建日期: 2008-11-17
// 概述: 合同类型
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 合同类型
    /// </summary>
    [Serializable]
    public class ContractType 
    {
        private byte[] _ContractTemplate;
        private int _ContractTypeID;
        private string _ContractTypeName;
        /// <summary>
        /// 合同构造函数
        /// </summary>
        /// <param name="contractTypeID"></param>
        /// <param name="contractTypeName"></param>
        public ContractType(int contractTypeID, string contractTypeName)
        {
            _ContractTypeID = contractTypeID;
            _ContractTypeName = contractTypeName;
        }
        /// <summary>
        /// 合同构造函数
        /// </summary>
        /// <param name="contractTypeID"></param>
        /// <param name="contractTypeName"></param>
        /// <param name="contractTemplate"></param>
        public ContractType(int contractTypeID, string contractTypeName,byte[] contractTemplate):this(contractTypeID,contractTypeName)
        {
            _ContractTemplate = contractTemplate;
        }

        /// <summary>
        /// 合同模板ID
        /// </summary>
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }

        /// <summary>
        /// 合同模板名称
        /// </summary>
        public string ContractTypeName
        {
            get { return _ContractTypeName; }
            set { _ContractTypeName = value;}
        }
        /// <summary>
        /// 合同模板
        /// </summary>
        public byte[] ContractTemplate
        {
            get { return _ContractTemplate; }
            set { _ContractTemplate = value; }
        }
        /// <summary>
        /// 判断是否有模板
        /// </summary>
        public bool HasTemplate
        {
            get { return _ContractTemplate==null?false:true; }
        }

    }
}