//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateEmployeeContract.cs
// 创建者: 张燕
// 创建日期: 2008-05-22
// 概述: 修改员工合同
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 更新员工合同
    /// </summary>
    public class UpdateEmployeeContract : Transaction
    {
        private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        private static IContract _DalContract = DalFactory.DataAccess.CreateContract();
        private static IContractType _DalContractType = DalFactory.DataAccess.CreateContractType();
        private static IEmployeeContractBookMark _DalEmployeeContractBookMark = DalFactory.DataAccess.CreateEmployeeContractBookMark();
        private readonly Employee _Employee;
        private readonly Contract _Contract;
        /// <summary>
        /// 更新员工合同构造函数
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        public UpdateEmployeeContract(Contract contract,Employee employee)
        {
            _Contract = contract;
            _Employee = employee;
        }
        /// <summary>
        /// 更新员工合同构造函数，测试
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        /// <param name="dalContract"></param>
        /// <param name="dalEmployee"></param>
        /// <param name="dalContractType"></param>
        /// <param name="dalEmployeeContractBookMark"></param>
        public UpdateEmployeeContract(Contract contract, Employee employee,
                       IContract dalContract, IEmployee dalEmployee,IContractType dalContractType,IEmployeeContractBookMark dalEmployeeContractBookMark)
        {
            _Contract = contract;
            _Employee = employee;
            _DalContract = dalContract;
            _DalEmployee = dalEmployee;
            _DalContractType = dalContractType;
            _DalEmployeeContractBookMark = dalEmployeeContractBookMark;
        }

        /// <summary>
        /// 调用下层的修改员工合同的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalContract.UpdateEmployeeContract(_Contract);

                    if (_Contract.EmployeeContractBookMark != null && _Contract.EmployeeContractBookMark.Count > 0)
                    {
                        _DalEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(_Contract.ContractID);
                        foreach (EmployeeContractBookMark o in _Contract.EmployeeContractBookMark)
                        {
                            o.EmployeeContractID = _Contract.ContractID;
                            _DalEmployeeContractBookMark.InsertEmployeeContractBookMark(o);
                        }
                    }

                    _DalContract.DeleteApplyAssessConditionsByEmployeeContractID(_Contract.ContractID);
                    if (_Contract.ApplyAssessConditions != null)
                    {
                        foreach (ApplyAssessCondition eachConditioin in _Contract.ApplyAssessConditions)
                        {
                            eachConditioin.EmployeeContractID = _Contract.ContractID;
                            _DalContract.InsertApplyAssessCondition(eachConditioin);
                        }
                    }
                    ts.Complete();
                }

            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// 修改员工合同有效性判断：
        /// 1、该员工是已经存在的员工
        /// 2、离职的员工不能签合同
        /// 3、该合同是已经存在的合同
        /// 4、合同类型必须是已经存在的合同类型
        /// </summary>
        protected override void Validation()
        {
            Employee employee = _DalEmployee.GetEmployeeByAccountID(_Employee.Account.Id);
            if (employee == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Name_Repeat);
            }
            else if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee)
            { 
                BllUtility.ThrowException(BllExceptionConst._Employee_HasLeft);
            }

            if (_DalContract.GetEmployeeContractByContractId(_Contract.ContractID)==null)
            {
                BllUtility.ThrowException(BllExceptionConst._Contract_NotExist);
            }
            if (_DalContractType.GetContractTypeByPkid(_Contract.ContractType.ContractTypeID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_NotExist);
            }
        }
    }
}