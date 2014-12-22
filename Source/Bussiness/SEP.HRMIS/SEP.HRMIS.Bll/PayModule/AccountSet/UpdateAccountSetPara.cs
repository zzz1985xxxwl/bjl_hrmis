//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAccountSetPara.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �޸����ײ���
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    /// <summary>
    /// ����������
    /// </summary>
    public class UpdateAccountSetPara : Transaction
    {
        private static IAccountSet _DalAccountSet = new AccountSetDal();
        private static IEmployeeAccountSet _DalEmployeeAccountSet =new EmployeeAccountSetDal();
        private readonly string _AccountSetParaName;
        private readonly FieldAttributeEnum _FieldAttributes;
        private readonly BindItemEnum _BindItem;
        private readonly MantissaRoundEnum _MantissaRoundEnum;
        private readonly string _OperatorName;
        private bool _IsAccountSetParaChanged;
        private readonly string _Description;
        private readonly int _AccountSetParaID;
        private AccountSetPara _OldAccountSetPara;
        private readonly bool _IsVisibleToEmployee;
        private readonly bool _IsVisibleWhenZero;
        /// <summary>
        /// ���캯��
        /// </summary>
        public UpdateAccountSetPara(int accountSetParaID, string accountSetParaName, FieldAttributeEnum fieldAttributes,
                                    BindItemEnum bindItem, MantissaRoundEnum mantissaRoundEnum, string description, string operatorName,
                                    bool isVisibleToEmployee, bool isVisibleWhenZero)
        {
            _OperatorName = operatorName;
            _AccountSetParaID = accountSetParaID;
            _AccountSetParaName = accountSetParaName;
            _FieldAttributes = fieldAttributes;
            _BindItem = bindItem;
            _MantissaRoundEnum = mantissaRoundEnum;
            _Description = description;
            _IsVisibleToEmployee = isVisibleToEmployee;
            _IsVisibleWhenZero = isVisibleWhenZero;
        }

        #region for unit test
        private AccountSetPara _AccountSetParaTest;
        /// <summary>
        /// for test
        /// </summary>
        public AccountSetPara AccountSetParaForTest
        {
            get { return _AccountSetParaTest; }
        }
        private List<EmployeeSalary> _EmployeeSalaryListTest;
        /// <summary>
        /// for test
        /// </summary>
        public List<EmployeeSalary> EmployeeSalaryListTest
        {
            get { return _EmployeeSalaryListTest; }
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public UpdateAccountSetPara(int accountSetParaID, string accountSetParaName, FieldAttributeEnum fieldAttributes,
                                    BindItemEnum bindItem, MantissaRoundEnum mantissaRoundEnum, string description, string operatorName,
                                    bool isVisibleToEmployee, bool isVisibleWhenZero, 
                                    IAccountSet iMockAccountSet, IEmployeeAccountSet iMockEmployeeAccountSet)
        {
            _OperatorName = operatorName;
            _AccountSetParaID = accountSetParaID;
            _AccountSetParaName = accountSetParaName;
            _FieldAttributes = fieldAttributes;
            _BindItem = bindItem;
            _MantissaRoundEnum = mantissaRoundEnum;
            _Description = description;
            _DalAccountSet = iMockAccountSet;
            _DalEmployeeAccountSet = iMockEmployeeAccountSet;
            _IsVisibleToEmployee = isVisibleToEmployee;
            _IsVisibleWhenZero = isVisibleWhenZero;
        }

        #endregion

        protected override void Validation()
        {
            //�ж��Ƿ����Para
            _OldAccountSetPara = _DalAccountSet.GetAccountSetParaByPKID(_AccountSetParaID);
            if (_OldAccountSetPara == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSetPara_IsNotExist);
            }
            //�ж��Ƿ�������
            if (_DalAccountSet.CountAccountSetParaByNameDiffPKID(_AccountSetParaID, _AccountSetParaName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSetParaName_Repeat);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalAccountSet.UpdateAccountSetPara(MakeAccountSetPara());
                    if (_IsAccountSetParaChanged)
                    {
                        UpdateEmployeeAccountSetWithNewPara();
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
        /// �������Ա��������
        /// </summary>
        private void UpdateEmployeeAccountSetWithNewPara()
        {
            List<EmployeeSalary> employeeSalarys =
                _DalEmployeeAccountSet.GetEmployeeAccountSetByAccountSetParaID(_AccountSetParaID);
            foreach (EmployeeSalary salary in employeeSalarys)
            {
                foreach (AccountSetItem item in salary.AccountSet.Items)
                {
                    if (item.AccountSetPara.AccountSetParaID == _AccountSetParaID)
                    {
                        item.AccountSetPara.AccountSetParaName = _AccountSetParaName;
                        item.AccountSetPara.IsVisibleToEmployee = _IsVisibleToEmployee;
                        item.AccountSetPara.IsVisibleWhenZero = _IsVisibleWhenZero;
                        item.AccountSetPara.Description = _Description;
                    }
                }
                UpdateEmployeeAccountSet updateEmployeeAccountSet =
                    new UpdateEmployeeAccountSet(salary.Employee.Account.Id, salary.AccountSet, _OperatorName,
                                                 DateTime.Now,
                                                 salary.AccountSet.Description + "��" + DateTime.Now.ToShortDateString() +
                                                 _OperatorName + "�޸����ײ���������ϵͳ�Զ�������ʷ��", _DalAccountSet,
                                                 _DalEmployeeAccountSet);
                updateEmployeeAccountSet.Excute();
            }
            _EmployeeSalaryListTest = employeeSalarys;

        }

        private AccountSetPara MakeAccountSetPara()
        {
            AccountSetPara accountSetPara = new AccountSetPara(_AccountSetParaID, _AccountSetParaName);
            accountSetPara.Description = _Description;
            accountSetPara.BindItem = _BindItem;
            accountSetPara.FieldAttribute = _FieldAttributes;
            accountSetPara.MantissaRound = _MantissaRoundEnum;
            accountSetPara.IsVisibleToEmployee = _IsVisibleToEmployee;
            accountSetPara.IsVisibleWhenZero = _IsVisibleWhenZero;

            if (_DalAccountSet.CountAccountSetItemByAccountSetParaID(_AccountSetParaID) > 0)
            {
                //������֡��Ƿ��Ա���ɼ�����Ϊ0ʱ�Ƿ���ʾ�޸��ˣ���Ҫ��Ա�������׽����޸�
                if (_OldAccountSetPara.AccountSetParaName != accountSetPara.AccountSetParaName
                    || _OldAccountSetPara.IsVisibleToEmployee != accountSetPara.IsVisibleToEmployee
                    || _OldAccountSetPara.IsVisibleWhenZero != accountSetPara.IsVisibleWhenZero)
                {
                    _IsAccountSetParaChanged = true;
                }
            }
            _AccountSetParaTest = accountSetPara;
            return accountSetPara;
        }
    }
}
