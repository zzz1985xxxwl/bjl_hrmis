//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TemporarySaveEmployeeAccountSet.cs
// ������: yyb
// ��������: 2008-12-24
// ����: �ݴ�
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Bll.PayModule.Tax;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    public class TemporarySaveEmployeeAccountSet : Transaction
    {
        private readonly IEmployeeSalary _DalEmployeeSalary = PayModuleDataAccess.CreateEmployeeSarary();
        private readonly int _EmployeeID;
        private readonly Model.PayModule.AccountSet _AccountSet;
        private readonly string _BackAccountsName;
        private readonly string _Description;
        private readonly DateTime _SalaryTime;
        private readonly IAccountSet _DalAccountSet = PayModuleDataAccess.CreateAccountSet();
        private readonly int _VersionNum;
        private readonly GetBindField _GetBindField = new GetBindField();
        private readonly GetTax _GetTax = new GetTax();

        public TemporarySaveEmployeeAccountSet(int salaryId,int employeeID, DateTime dt, Model.PayModule.AccountSet accountSet, string backAcountsName,string description,int versionNum)
        {
            _EmployeeSalaryID = salaryId;
            _EmployeeID = employeeID;
            //_SalaryTime = Convert.ToDateTime(dt.Year + "-" + dt.Month);
            _SalaryTime = dt;
            _Description = description;
            _AccountSet = accountSet;
            _BackAccountsName = backAcountsName;
            _VersionNum = versionNum;
        }

        public TemporarySaveEmployeeAccountSet(int salaryId, int employeeID, DateTime dt, Model.PayModule.AccountSet accountSet, string backAcountsName, string description, int versionNum, IEmployeeSalary mockSalary, IAccountSet mockaccountSet)
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

        private int _EmployeeSalaryID;
        public int EmployeeSalaryID
        {
            get { return _EmployeeSalaryID; }
            set { _EmployeeSalaryID = value; }
        }

        protected override void Validation()
        {
            //�ж����ײ����Ƿ�Ϊ��
            if (_AccountSet != null && _AccountSet.AccountSetID != 0)
            {
                //�ж����ݿ���װ���Ƿ����
                if (_DalAccountSet.GetWholeAccountSetByPKID(_AccountSet.AccountSetID) == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_NotExist);
                }
            }
            //�ж����ݿ��Ƿ���ڼ�¼
            EmployeeSalaryHistory history = _DalEmployeeSalary.GetEmployeeSalaryHistoryByPKID(_EmployeeSalaryID);
            if (history == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Salary_NotExist);
            }
            else if(history.EmployeeSalaryStatus==EmployeeSalaryStatusEnum.AccountClosed)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Salary_Closed); 
            }
        }

        /// <summary>
        /// ����н��
        /// </summary>
        protected override void ExcuteSelf()
        {
            EmployeeSalaryHistory salary = MakeEmployeeSalary();
            EmployeeSalaryID = _DalEmployeeSalary.UpdateEmployeeSalaryHistory(_EmployeeID, salary);
        }

        /// <summary>
        /// ��װ����
        /// </summary>
        /// <returns></returns>
        private EmployeeSalaryHistory MakeEmployeeSalary()
        {
            EmployeeSalaryHistory salaryHistory=new EmployeeSalaryHistory();
            salaryHistory.EmployeeAccountSet = _AccountSet;
            salaryHistory.HistoryId = _EmployeeSalaryID;
            if (_AccountSet != null && _AccountSet.Items != null)
            {

                BindItemValueCollection _BindItemValueCollection = ExecutBindValue(_EmployeeID, _SalaryTime);
                //��ȡ��ֵ
                foreach (AccountSetItem item in _AccountSet.Items)
                {
                    if (item != null && item.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.BindField.Id)
                    {
                        item.CalculateResult = _BindItemValueCollection.GetBindItemValue(item.AccountSetPara.BindItem);
                    }
                }
                //todo ˫н
                //_AccountSet.CalculateItemList(_GetTax.GetIndividualIncomeTax(),null,1);
                _AccountSet.CalculateItemList(_GetTax.GetIndividualIncomeTax(), MakeEmployeeLastYearSalary(_EmployeeID), new HrmisUtility().EndMonthByYearMonth(_SalaryTime).Month);
            }
            salaryHistory.Description = _Description;
            salaryHistory.SalaryDateTime = _SalaryTime;
            salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
            salaryHistory.AccountsBackName = _BackAccountsName;
            salaryHistory.VersionNumber = _VersionNum;
            return salaryHistory;
        }

        /// <summary>
        /// ִ�л�ȡ��ֵ����
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="salaryTime"></param>
        private BindItemValueCollection ExecutBindValue(int accountID, DateTime salaryTime)
        {
            DateTime timeFrom = salaryTime;
            DateTime timeTo = salaryTime.AddMonths(1).AddDays(-1);
            return _GetBindField.BindItemValueCollection(accountID, timeFrom, timeTo);
        }

        /// <summary>
        /// ȡ��ʮ���¹���
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        private List<EmployeeSalaryHistory> MakeEmployeeLastYearSalary(int accountID)
        {
            List<EmployeeSalaryHistory> returnList = new List<EmployeeSalaryHistory>();
            List<EmployeeSalaryHistory> historyList = _DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(accountID);
            foreach (EmployeeSalaryHistory history in historyList)
            {
                if (new HrmisUtility().EndMonthByYearMonth(history.SalaryDateTime).Year.Equals(new HrmisUtility().EndMonthByYearMonth(_SalaryTime).Year - 1))
                {
                    returnList.Add(history);
                }
            }
            return returnList;
        }
    }
}
