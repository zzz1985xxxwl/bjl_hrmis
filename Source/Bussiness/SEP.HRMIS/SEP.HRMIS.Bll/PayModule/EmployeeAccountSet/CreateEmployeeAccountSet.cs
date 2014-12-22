//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CreateEmployeeAccountSet.cs
// 创建者: yyb
// 创建日期: 2008-12-24
// 概述: 1 为员工设置帐套，获得自己的帐套
//       2 给帐套赋初始值，并得记录调薪历史的结果
// ----------------------------------------------------------------

using System;
using System.Transactions;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    public class CreateEmployeeAccountSet : Transaction
    { 
        private readonly int _EmployeeID;
        private Model.PayModule.AccountSet _AccountSet;
        private readonly string _BackAccountsName;
        private readonly DateTime _ChangeDate;
        private readonly string _Description;

        private readonly IAccountSet _DalAccountSet = new AccountSetDal();
        private readonly IEmployeeAccountSet _DalEmployeeAccountSet =new EmployeeAccountSetDal();

        private int _EmployeeAccountSetID;
        public int EmployeeAccountSetID
        {
            get { return _EmployeeAccountSetID; }
            set { _EmployeeAccountSetID = value; }
        }

        public CreateEmployeeAccountSet(int employeeID, Model.PayModule.AccountSet accountSet,
            string backAccountsName, DateTime changeDate, string description)
        {
            _EmployeeID = employeeID;
            _AccountSet = accountSet;
            _BackAccountsName = backAccountsName;
            _ChangeDate = changeDate;
            _Description = description;
        }

        public CreateEmployeeAccountSet(int employeeID, Model.PayModule.AccountSet accountSet,
            string backAccountsName, DateTime changeDate, string description, IAccountSet mockAccountSet, IEmployeeAccountSet mockEmployeeAccountSet)
        {
            _EmployeeID = employeeID;
            _AccountSet = accountSet;
            _BackAccountsName = backAccountsName;
            _ChangeDate = changeDate;
            _Description = description;
            _DalAccountSet = mockAccountSet;
            _DalEmployeeAccountSet = mockEmployeeAccountSet;
        }

        protected override void Validation()
        {
            if (_AccountSet == null)
            {
                BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_IsNull);
            }
            else if (_DalAccountSet.GetWholeAccountSetByPKID(_AccountSet.AccountSetID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_AccountSet_NotExist);
            }
            //if (string.IsNullOrEmpty(_BackAccountsName))
            //{
            //    BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_BackAccountsName_IsNull);
            //}
            //if (string.IsNullOrEmpty(_EmployeeID.ToString()))
            //{
            //    BllUtility.ThrowException(BllExceptionConst._EmployeeAccountSet_EmployeeID_IsNull);
            //}
        }

        protected override void ExcuteSelf()
        {
            try
            {
                Model.PayModule.AccountSet accountSet = _DalAccountSet.GetWholeAccountSetByPKID(_AccountSet.AccountSetID);
                if (accountSet != null && accountSet.Items != null)
                {
                    for (int i = 0; i < accountSet.Items.Count; i++)
                    {
                        for (int j = 0; j < _AccountSet.Items.Count; j++)
                        {
                            if (accountSet.Items[i].AccountSetPara.AccountSetParaID ==
                                _AccountSet.Items[j].AccountSetPara.AccountSetParaID)
                            {
                                accountSet.Items[i].CalculateResult = _AccountSet.Items[j].CalculateResult;
                            }
                        }
                    }
                }

                _AccountSet = accountSet;
                _AccountSet.Description = _Description;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    EmployeeAccountSetID = _DalEmployeeAccountSet.InsertEmployeeAccountSet(_EmployeeID, _AccountSet);
                    _DalEmployeeAccountSet.InsertAdjustSalaryHistory(_EmployeeID, CreateAdjustSalaryHistory());
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private AdjustSalaryHistory CreateAdjustSalaryHistory()
        {
            AdjustSalaryHistory adjustSalaryHistory = new AdjustSalaryHistory();
            adjustSalaryHistory.AccountsBackName = _BackAccountsName;
            adjustSalaryHistory.AccountSet = _AccountSet;
            adjustSalaryHistory.ChangeDate = _ChangeDate;
            adjustSalaryHistory.Description = _Description;
            return adjustSalaryHistory;
        }
    }
}
