//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddContractType.cs
// 创建者: 张燕
// 创建日期: 2008-05-21
// 概述: 新增参数
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 新增合同类型
    /// </summary>
    public class AddContractType : Transaction
    {
        private static IContractType _DalContractType = DalFactory.DataAccess.CreateContractType();
        private readonly ContractType _ContractType;
        /// <summary>
        /// 新增合同类型构造函数
        /// </summary>
        /// <param name="contractType"></param>
        public AddContractType(ContractType contractType)
        {
            _ContractType = contractType;
        }

        /// <summary>
        /// AddContractType的构造函数，专为测试提供
        /// </summary>
        public AddContractType(ContractType contractType, IContractType dalContractType)
        {

            _ContractType = contractType;
            _DalContractType = dalContractType;
        }

        /// <summary>
        /// 调用下层的新增合同类型的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            //try
            //{
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _ContractType.ContractTypeID = _DalContractType.InsertContractType(_ContractType);
                    new CreateContractBookMark(_ContractType);
                    ts.Complete();
                }

            //}
            //catch
            //{
            //    BllUtility.ThrowException(BllExceptionConst._DbError);
            //}
        }

        /// <summary>
        /// 新增合同类型有效性判断：
        /// 1、合同类型不能与已有合同类型重名
        /// </summary>
        protected override void Validation()
        {
            //合同类型不能与已有合同类型重名
            if (_DalContractType.CountContractTypeByName(_ContractType.ContractTypeName) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_Repeat);
            }
        }
    }
}