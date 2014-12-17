//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteEmployeeContract.cs
// 创建者: 张燕
// 创建日期: 2008-05-22
// 概述: 删除员工合同
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 删除员工合同
    /// </summary>
    public class DeleteEmployeeContract : Transaction
    {
        private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        private static IContract _DalContract = DalFactory.DataAccess.CreateContract();
        private static IEmployeeContractBookMark _DalEmployeeContractBookMark = DalFactory.DataAccess.CreateEmployeeContractBookMark();
        private readonly int _EmployeeID;
        private readonly int _ContractID;
        /// <summary>
        /// 删除员工合同构造函数
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="employeeID"></param>
        public DeleteEmployeeContract(int contractID, int employeeID)
        {
            _ContractID = contractID;
            _EmployeeID = employeeID;
        }
        /// <summary>
        /// 删除员工合同构造函数，测试
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="employeeID"></param>
        /// <param name="dalContract"></param>
        /// <param name="dalEmployee"></param>
        /// <param name="dalEmployeeContractBookMark"></param>
        public DeleteEmployeeContract(int contractID, int employeeID, IContract dalContract, IEmployee dalEmployee,IEmployeeContractBookMark dalEmployeeContractBookMark)
        {
            _ContractID = contractID;
            _EmployeeID = employeeID;
            _DalContract = dalContract;
            _DalEmployee = dalEmployee;
            _DalEmployeeContractBookMark = dalEmployeeContractBookMark;
        }

        /// <summary>
        /// 调用下层的删除员工合同的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalContract.DeleteApplyAssessConditionsByEmployeeContractID(_ContractID);
                    _DalEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(_ContractID);
                    _DalContract.DeleteEmployeeContract(_ContractID);
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// 删除员工合同有效性判断：
        /// 1、该员工必须是已经存在的员工
        /// 2、该合同必须是已经存在的合同
        /// </summary>
        protected override void Validation()
        {
            if (_DalEmployee.GetEmployeeByAccountID(_EmployeeID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Name_NotExist);
            }
            if (_DalContract.GetEmployeeContractByContractId(_ContractID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Contract_NotExist);
            }
        }
    }
}