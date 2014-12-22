//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SaveEmployeeWelfare.cs
// Creater:  Xue.wenlong
// Date:  2008-12-24
// Resume:����Ա��������Ϣ��������£�û��������
// ----------------------------------------------------------------

using System;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ����Ա��������Ϣ
    /// </summary>
    public class SaveEmployeeWelfare : Transaction
    {
        private static IEmployeeWelfare _EmployeeWelfareDal = new EmployeeWelfareDal();
        private static IEmployeeWelfareHistory _EmployeeWelfareHistoryDal = new EmployeeWelfareHistoryDal();
        private readonly int _EmployeeID;
        private readonly EmployeeWelfare _EmployeeWelfare;
        private readonly string _OperationName;
        private int _EmployeeWelfareID;

        /// <summary>
        /// ����Ա��������Ϣ���캯��
        /// </summary>
        public SaveEmployeeWelfare(int employeeID, SocialSecurityTypeEnum socialSecurityType,
                                   decimal? socialSecurityBase, DateTime? socialSecurityEffectiveYearMonth,
                                   string accumulationFundAccount, DateTime? accumulationFundEffectiveYearMonth,
                                   decimal? accumulationFundBase, string operationName,
                                   string accumulationFundSupplyAccount, decimal? accumulationFundSupplyBase,
                                    decimal? yangLaoBase, decimal? shiYeBase, decimal? yiLiaoBase)
        {
            _EmployeeID = employeeID;
            EmployeeSocialSecurity employeeSocialSecurity =
                new EmployeeSocialSecurity(socialSecurityType, socialSecurityBase, socialSecurityEffectiveYearMonth,
                                           yangLaoBase, shiYeBase, yiLiaoBase);
            EmployeeAccumulationFund employeeAccumulationFund =
                new EmployeeAccumulationFund(accumulationFundAccount, accumulationFundBase,
                                             accumulationFundEffectiveYearMonth, accumulationFundSupplyAccount,
                                             accumulationFundSupplyBase);
            _EmployeeWelfare = new EmployeeWelfare(employeeSocialSecurity, employeeAccumulationFund);
            _OperationName = operationName;
        }

        /// <summary>
        /// ����Ա��������Ϣ���캯��������
        /// </summary>
        public SaveEmployeeWelfare(int employeeID, SocialSecurityTypeEnum socialSecurityType,
                                   decimal? socialSecurityBase, DateTime? socialSecurityEffectiveYearMonth,
                                   string accumulationFundAccount, DateTime? accumulationFundEffectiveYearMonth,
                                   decimal? accumulationFundBase, string operationName,
                                   string accumulationFundSupplyAccount, decimal? accumulationFundSupplyBase,
                                    decimal? yangLaoBase, decimal? shiYeBase, decimal? yiLiaoBase,
                                   IEmployeeWelfare mockIEmployeeWelfare,
                                   IEmployeeWelfareHistory mockIEmployeeWelfareHistory)
        {
            _EmployeeID = employeeID;
            EmployeeSocialSecurity employeeSocialSecurity =
                new EmployeeSocialSecurity(socialSecurityType, socialSecurityBase, socialSecurityEffectiveYearMonth,
                                           yangLaoBase, shiYeBase, yiLiaoBase);
            EmployeeAccumulationFund employeeAccumulationFund =
                new EmployeeAccumulationFund(accumulationFundAccount, accumulationFundBase,
                                             accumulationFundEffectiveYearMonth, accumulationFundSupplyAccount,
                                             accumulationFundSupplyBase);
            _EmployeeWelfare = new EmployeeWelfare(employeeSocialSecurity, employeeAccumulationFund);
            _OperationName = operationName;
            _EmployeeWelfareDal = mockIEmployeeWelfare;
            _EmployeeWelfareHistoryDal = mockIEmployeeWelfareHistory;
        }

        /// <summary>
        /// EmployeeWelfareID�������
        /// </summary>
        public int EmployeeWelfareID
        {
            get { return _EmployeeWelfareID; }
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            EmployeeWelfare employeeWelfareDatabase = _EmployeeWelfareDal.GetEmployeeWelfareByAccountID(_EmployeeID);

            if (!_EmployeeWelfare.Equals(employeeWelfareDatabase))
            {
                try
                {
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        if (employeeWelfareDatabase == null)
                        {
                            _EmployeeWelfareID =
                                _EmployeeWelfareDal.InsertEmployeeWelfareByAccountID(_EmployeeWelfare, _EmployeeID);
                        }
                        else
                        {
                            _EmployeeWelfareDal.UpdateEmployeeWelfareByAccountID(_EmployeeWelfare, _EmployeeID);
                        }
                        new CreateEmployeeWelfareHistoryByAccountID(_EmployeeWelfare, _EmployeeID, _OperationName,
                                                                    DateTime.Now,
                                                                    _EmployeeWelfareHistoryDal).Excute();
                        ts.Complete();
                    }
                }
                catch
                {
                    BllUtility.ThrowException(BllExceptionConst._DbError);
                }
            }
        }

        #region for test

        /// <summary>
        /// IEmployeeWelfare��mock
        /// </summary>
        public IEmployeeWelfare MockIEmployeeWelfare
        {
            set { _EmployeeWelfareDal = value; }
        }

        /// <summary>
        /// IEmployeeWelfareHistory��mock
        /// </summary>
        public IEmployeeWelfareHistory MockIEmployeeWelfareHistroy
        {
            set { _EmployeeWelfareHistoryDal = value; }
        }

        #endregion
    }
}