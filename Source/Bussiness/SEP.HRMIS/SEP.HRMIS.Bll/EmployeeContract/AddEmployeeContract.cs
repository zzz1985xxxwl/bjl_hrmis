//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddEmployeeContract.cs
// ������: ����
// ��������: 2008-05-22
// ����: ����Ա����ͬ
// ----------------------------------------------------------------

using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ����Ա����ͬ
    /// </summary>
    public class AddEmployeeContract : Transaction
    {
        private static IEmployee _DalEmployee = new EmployeeDal();
        private static IContractType _DalContractType = new ContractTypeDal();
        private static IContract _DalContract = new ContractDal();
        private static IEmployeeContractBookMark _DalEmployeeContractBookMark = new EmployeeContractBookMarkDal();
        private readonly Employee _Employee;
        private readonly Contract _Contract;
        /// <summary>
        /// ����Ա����ͬ���캯��
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        public AddEmployeeContract(Contract contract, Employee employee)
        {
            _Contract = contract;
            _Employee = employee;
        }
        /// <summary>
        /// ����Ա����ͬ���캯��������
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        /// <param name="dalContract"></param>
        /// <param name="dalEmployee"></param>
        /// <param name="dalContractType"></param>
        /// <param name="dalEmployeeContractBookMark"></param>
        public AddEmployeeContract(Contract contract, Employee employee,
            IContract dalContract, IEmployee dalEmployee, IContractType dalContractType, IEmployeeContractBookMark dalEmployeeContractBookMark)
        {
            _Contract = contract;
            _Employee = employee;
            _DalContract = dalContract;
            _DalEmployee = dalEmployee;
            _DalContractType = dalContractType;
            _DalEmployeeContractBookMark = dalEmployeeContractBookMark;
        }

        /// <summary>
        /// �����²������Ա����ͬ�ķ���
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    int employeeContractID = _DalContract.InsertEmployeeContract(_Employee.Account.Id, _Contract);
                    if (_Contract.EmployeeContractBookMark != null && _Contract.EmployeeContractBookMark.Count > 0)
                    {
                        _DalEmployeeContractBookMark.DeleteEmployeeContractBookMarkByContractID(employeeContractID);
                        foreach (EmployeeContractBookMark o in _Contract.EmployeeContractBookMark)
                        {
                            o.EmployeeContractID = employeeContractID;
                            _DalEmployeeContractBookMark.InsertEmployeeContractBookMark(o);
                        }
                    }
                    if (_Contract.ApplyAssessConditions != null)
                    {
                        foreach (ApplyAssessCondition eachConditioin in _Contract.ApplyAssessConditions)
                        {
                            eachConditioin.EmployeeContractID = employeeContractID;
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
        /// ����Ա����ͬ��Ч���жϣ�
        /// 1��Ҫǩ��ͬ��Ա�����Ѿ����ڵ�Ա��
        /// 2����ְ��Ա������ǩ��ͬ 
        /// 3����ͬ���ͱ������Ѿ����ڵĺ�ͬ����
        /// </summary>
        protected override void Validation()
        {
            Employee employee = _DalEmployee.GetEmployeeByAccountID(_Employee.Account.Id);
            if (employee == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Name_NotExist);
            }
            else if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_HasLeft);
            }
            if (_DalContractType.GetContractTypeByPkid(_Contract.ContractType.ContractTypeID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_NotExist);
            }
        }
    }
}