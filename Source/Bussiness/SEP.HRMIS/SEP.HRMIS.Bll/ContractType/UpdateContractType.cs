//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateContractType.cs
// 创建者: 张燕
// 创建日期: 2008-05-21
// 概述: 修改参数
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 修改合同类型
    /// </summary>
    public class UpdateContractType : Transaction
    {
        private static IContractType _DalContractType = new ContractTypeDal();
        private readonly ContractType _ContractType;
        /// <summary>
        /// 合同类型构造函数
        /// </summary>
        /// <param name="contractType"></param>
        public UpdateContractType(ContractType contractType)
        {
            _ContractType = contractType;
        }
        /// <summary>
        /// 合同类型构造函数
        /// </summary>
        /// <param name="contractType"></param>
        /// <param name="dalContractType"></param>
        public UpdateContractType(ContractType contractType, IContractType dalContractType)
        {
            _ContractType = contractType;
            _DalContractType = dalContractType;
        }

        //修改合同类型业务逻辑：
        //判断有效性
        //如果通过判断
        // 调用下层的修改合同类型的方法
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalContractType.UpdateContractType(_ContractType);
                    new CreateContractBookMark(_ContractType);
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        // 修改合同类型有效性判断：
        //1、修改的类型要存在
        //2、合同类型不能与已有的其他合同类型重名
        protected override void Validation()
        {
            if (_DalContractType.GetContractTypeByPkid(_ContractType.ContractTypeID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_NotExist);
            }
            if (_DalContractType.CountContractTypeByNameDiffPKID(_ContractType.ContractTypeID, _ContractType.ContractTypeName) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_Repeat);
            }
        }
    }
}
