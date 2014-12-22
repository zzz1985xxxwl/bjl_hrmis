//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddContractType.cs
// 创建者: 张燕
// 创建日期: 2008-05-21
// 概述: 删除参数
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 删除合同类型
    /// </summary>
    public class DeleteContractType : Transaction
    {
        private static IContractType _DalContractType = new ContractTypeDal();
        private static IContractBookMark _ContractBookMark = new ContractBookMarkDal();
        private static IContract _DalContract = new ContractDal();
        private readonly int _ContractTypeId;
        /// <summary>
        /// 删除合同类型
        /// </summary>
        /// <param name="contractTypeId"></param>
        public DeleteContractType(int contractTypeId)
        {
            _ContractTypeId = contractTypeId;
        }

        /// <summary>
        /// 删除合同类型，测试用
        /// </summary>
        public DeleteContractType(int contractTypeId, IContractType dalContractType, IContract dalContract,IContractBookMark dalContractBookMark)
        {
            _ContractTypeId = contractTypeId;
            _DalContractType = dalContractType;
            _DalContract = dalContract;
            _ContractBookMark = dalContractBookMark;

        }

        /// <summary>
        /// 调用下层的删除合同类型的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalContractType.DeleteContractType(_ContractTypeId);
                    _ContractBookMark.DeleteContractBookMarkByContractTypeID(_ContractTypeId);
                    ts.Complete();
                }
                
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// 删除合同类型有效性判断：
        /// 1、要删除的合同类型必须是已经存在的合同类型
        /// 2、没有合同属于这个要删除的合同类型
        /// </summary>
        protected override void Validation()
        {
            if (_DalContractType.GetContractTypeByPkid(_ContractTypeId) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_NotExist);
            }
            if (_DalContract.GetEmployeeContractByContractTypeId(_ContractTypeId).Count!=0)
            {
                BllUtility.ThrowException(BllExceptionConst._ConstractType_HasConstract);

            }
        }
    }
}
