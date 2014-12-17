//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteEmployeeContract.cs
// ������: ����
// ��������: 2008-05-22
// ����: ɾ��Ա����ͬ
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ɾ��Ա����ͬ
    /// </summary>
    public class DeleteEmployeeContract : Transaction
    {
        private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        private static IContract _DalContract = DalFactory.DataAccess.CreateContract();
        private static IEmployeeContractBookMark _DalEmployeeContractBookMark = DalFactory.DataAccess.CreateEmployeeContractBookMark();
        private readonly int _EmployeeID;
        private readonly int _ContractID;
        /// <summary>
        /// ɾ��Ա����ͬ���캯��
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="employeeID"></param>
        public DeleteEmployeeContract(int contractID, int employeeID)
        {
            _ContractID = contractID;
            _EmployeeID = employeeID;
        }
        /// <summary>
        /// ɾ��Ա����ͬ���캯��������
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
        /// �����²��ɾ��Ա����ͬ�ķ���
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
        /// ɾ��Ա����ͬ��Ч���жϣ�
        /// 1����Ա���������Ѿ����ڵ�Ա��
        /// 2���ú�ͬ�������Ѿ����ڵĺ�ͬ
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