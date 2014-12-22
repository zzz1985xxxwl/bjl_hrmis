//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AccountReopenedEmployeeAccountSet.cs
// ������: yyb
// ��������: 2008-12-24
// ����: �����ٷ��ʣ�������޸�Ա�����Ź�����ʷ�Ľ��
// ----------------------------------------------------------------

using System;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    public class AccountReopenedEmployeeAccountSet : Transaction
    {
        private readonly IEmployeeSalary _DalEmployeeSalary = new EmployeeSalaryDal();
        private readonly int _EmployeeID;
        private readonly Model.PayModule.AccountSet _AccountSet;
        private readonly string _BackAccountsName;
        private readonly string _Description;
        private readonly DateTime _SalaryTime;
        private readonly IAccountSet _DalAccountSet = new AccountSetDal();
        private readonly int _VersionNum;
        private readonly int _EmployeeSalaryID;

        //for test
        public AccountReopenedEmployeeAccountSet(int salaryId, int employeeID, DateTime dt, Model.PayModule.AccountSet accountSet, string backAcountsName, string description, int versionNum, IEmployeeSalary mockSalary, IAccountSet mockaccountSet)
        {
            _EmployeeSalaryID = salaryId;
            _EmployeeID = employeeID;
            _SalaryTime = dt;
            _Description = description;
            _AccountSet = accountSet;
            _BackAccountsName = backAcountsName;
            _VersionNum = versionNum;
            _DalEmployeeSalary = mockSalary;
            _DalAccountSet = mockaccountSet;
        }

        public AccountReopenedEmployeeAccountSet(int salaryId, int employeeID, DateTime dt, Model.PayModule.AccountSet accountSet, string backAcountsName, string description, int versionNum)
        {
            _EmployeeSalaryID = salaryId;
            _EmployeeID = employeeID;
            _SalaryTime = dt;
            _Description = description;
            _AccountSet = accountSet;
            _BackAccountsName = backAcountsName;
            _VersionNum = versionNum;
        }

        protected override void Validation()
        {
            //�ж����ײ����Ƿ�Ϊ��
            if (_AccountSet == null)
            {
                BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_IsNull);
            }
            //�ж����ݿ���װ���Ƿ����
            else if (_DalAccountSet.GetWholeAccountSetByPKID(_AccountSet.AccountSetID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_NotExist);
            }
            //�ж����ݿ����Ƿ����
            EmployeeSalaryHistory history = _DalEmployeeSalary.GetEmployeeSalaryHistoryByPKID(_EmployeeSalaryID);
            if (history == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Salary_NotExist);
            }
            //�ж������Ƿ����ڷ��ʽ׶�
            else if (history.EmployeeSalaryStatus != EmployeeSalaryStatusEnum.AccountClosed)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Salary_Not_Closed);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalEmployeeSalary.UpdateEmployeeSalaryHistory(_EmployeeID, MakeEmployeeSalary());
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// ��װнˮ����
        /// </summary>
        /// <returns></returns>
        private EmployeeSalaryHistory MakeEmployeeSalary()
        {
            EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
            salaryHistory.EmployeeAccountSet = _AccountSet;
            salaryHistory.HistoryId = _EmployeeSalaryID;
            if (_AccountSet.Items != null)
            {
                foreach (AccountSetItem item in _AccountSet.Items)
                {
                    if (item.AccountSetPara.FieldAttribute.GetType().Equals(FieldAttributeEnum.CalculateField))
                    {
                        //to do caculate
                    }
                }
            }
            salaryHistory.Description = _Description;
            salaryHistory.SalaryDateTime = _SalaryTime;
            salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.AccountReopened;
            salaryHistory.AccountsBackName = _BackAccountsName;
            salaryHistory.VersionNumber = _VersionNum;
            return salaryHistory;
        }
    }
}
