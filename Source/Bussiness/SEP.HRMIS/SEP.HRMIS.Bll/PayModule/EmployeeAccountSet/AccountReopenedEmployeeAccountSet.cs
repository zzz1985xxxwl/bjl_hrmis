//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountReopenedEmployeeAccountSet.cs
// 创建者: yyb
// 创建日期: 2008-12-24
// 概述: 解封后再封帐，并获得修改员工发放工资历史的结果
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
            //判断帐套参数是否为空
            if (_AccountSet == null)
            {
                BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_IsNull);
            }
            //判断数据库中装套是否存在
            else if (_DalAccountSet.GetWholeAccountSetByPKID(_AccountSet.AccountSetID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_NotExist);
            }
            //判断数据库中是否存在
            EmployeeSalaryHistory history = _DalEmployeeSalary.GetEmployeeSalaryHistoryByPKID(_EmployeeSalaryID);
            if (history == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Salary_NotExist);
            }
            //判断流程是否正在封帐阶段
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
        /// 组装薪水数据
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
