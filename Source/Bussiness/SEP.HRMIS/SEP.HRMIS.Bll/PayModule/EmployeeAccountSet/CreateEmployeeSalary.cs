//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CreateEmployeeSalary.cs
// ������: ����
// ��������: 2008-12-28
// ����: �½�Ա�����ʼ�¼
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.PayModule.Tax;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    ///<summary>
    ///</summary>
    public class CreateEmployeeSalary : Transaction
    {
        private readonly IEmployeeSalary _DalEmployeeSalary = new EmployeeSalaryDal();
        private readonly IEmployeeAccountSet _DalEmployeeAccountSet =new EmployeeAccountSetDal();
        private readonly int _EmployeeID;
        private EmployeeSalary _AccountSet;
        private readonly string _BackAccountsName;
        private readonly string _Description;
        private readonly DateTime _SalaryTime;
        private readonly IAccountSet _DalAccountSet = new AccountSetDal();
        private readonly GetBindField _GetBindField=new GetBindField();
        private readonly GetTax _GetTax=new GetTax();

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="dt"></param>
        ///<param name="backAcountsName"></param>
        ///<param name="description"></param>
        public CreateEmployeeSalary(int employeeID, DateTime dt, string backAcountsName, string description)
        {
            _EmployeeID = employeeID;
            _SalaryTime = dt;
            _Description = description;
            _BackAccountsName = backAcountsName;
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="dt"></param>
        ///<param name="backAcountsName"></param>
        ///<param name="description"></param>
        ///<param name="mockSalary"></param>
        ///<param name="mockaccountSet"></param>
        ///<param name="mockEmployeeAccountSet"></param>
        public CreateEmployeeSalary(int employeeID, DateTime dt, string backAcountsName, string description, IEmployeeSalary mockSalary, IAccountSet mockaccountSet,IEmployeeAccountSet mockEmployeeAccountSet)
        {
            _EmployeeID = employeeID;
            _SalaryTime = dt;
            _Description = description;
            _BackAccountsName = backAcountsName;
            _DalEmployeeSalary = mockSalary;
            _DalAccountSet = mockaccountSet;
            _DalEmployeeAccountSet = mockEmployeeAccountSet;
        }

        private int _EmployeeSalaryID;
        ///<summary>
        ///</summary>
        public int EmployeeSalaryID
        {
            get { return _EmployeeSalaryID; }
            set { _EmployeeSalaryID = value; }
        }

        protected override void Validation()
        {
            _AccountSet = _DalEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(_EmployeeID);
            //�ж����ײ����Ƿ�Ϊ��
            if (_AccountSet != null && _AccountSet.AccountSet != null)
            {
                //�ж����ݿ���װ���Ƿ����
                if (_DalAccountSet.GetWholeAccountSetByPKID(_AccountSet.AccountSet.AccountSetID) == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_NotExist);
                }
            }

            //�жϸ��¹����Ƿ��ѳ�ʼ��
            if (_DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(_EmployeeID, _SalaryTime) != null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Salary_Exist);
            }
        }

        /// <summary>
        /// ��id�ǳ�ʼ��н�ʻ��Ǹ���н��
        /// </summary>
        protected override void ExcuteSelf()
        {
            EmployeeSalaryHistory salary;
            if (_AccountSet != null && _AccountSet.AccountSet != null)
            {
                salary = MakeEmployeeSalary();
            }
            else
            {
                salary = MakeEmployeeSalaryWithoutAccountSet();
            }
            EmployeeSalaryID = _DalEmployeeSalary.InsertEmployeeSalaryHistory(_EmployeeID, salary);
        }

        /// <summary>
        /// ��װ����
        /// </summary>
        /// <returns></returns>
        private EmployeeSalaryHistory MakeEmployeeSalary()
        {
            EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
            salaryHistory.EmployeeAccountSet = _AccountSet.AccountSet;
            salaryHistory.HistoryId = _EmployeeSalaryID;
            if (_AccountSet.AccountSet != null && _AccountSet.AccountSet.Items != null)
            {
                BindItemValueCollection _BindItemValueCollection = ExecutBindValue(_EmployeeID, _SalaryTime);
                //��ȡ��ֵ
                foreach (AccountSetItem item in _AccountSet.AccountSet.Items)
                {
                    if (item != null && item.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.BindField.Id)
                    {
                        item.CalculateResult = _BindItemValueCollection.GetBindItemValue(item.AccountSetPara.BindItem);
                    }
                }
                //todo ˫н
                //_AccountSet.AccountSet.CalculateItemList(_GetTax.GetIndividualIncomeTax(), null, 1);
                _AccountSet.AccountSet.CalculateItemList(_GetTax.GetIndividualIncomeTax(), MakeEmployeeLastYearSalary(_EmployeeID), new HrmisUtility().EndMonthByYearMonth(_SalaryTime).Month);
            }
            salaryHistory.Description = _Description;
            salaryHistory.SalaryDateTime = _SalaryTime;
            salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
            salaryHistory.AccountsBackName = _BackAccountsName;
            return salaryHistory;
        }

        private EmployeeSalaryHistory MakeEmployeeSalaryWithoutAccountSet()
        {
            EmployeeSalaryHistory salaryHistory = new EmployeeSalaryHistory();
            Model.PayModule.AccountSet temp = new Model.PayModule.AccountSet(0, string.Empty);
            salaryHistory.EmployeeAccountSet = temp;

            salaryHistory.Description = _Description;
            salaryHistory.SalaryDateTime = _SalaryTime;
            salaryHistory.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
            salaryHistory.AccountsBackName = _BackAccountsName;
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
        public List<EmployeeSalaryHistory> MakeEmployeeLastYearSalary(int accountID)
        {
            List<EmployeeSalaryHistory> returnList=new List<EmployeeSalaryHistory>();
           List<EmployeeSalaryHistory> historyList=_DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(accountID);
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
