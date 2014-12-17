//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeAccumulationFund.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:������
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class EmployeeAccumulationFund
    {
        private string _Account;
        private string _SupplyAccount;
        private decimal? _Base;
        private DateTime? _EffectiveYearMonth;
        private string _BaseTemp;
        private List<string> _EffectiveYearMonthTemp;
        private decimal? _SupplyBase;

        public EmployeeAccumulationFund(string account, decimal? basenum, DateTime? effectiveYearMonth,
                                        string supplyAccount, decimal? supplyBase)
        {
            _Account = account;
            _Base = basenum;
            _EffectiveYearMonth = effectiveYearMonth;
            _SupplyAccount = supplyAccount;
            _SupplyBase = supplyBase;
        }

        #region ����

        /// <summary>
        /// �������ʺ�
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// ���乫�����ʺ�
        /// </summary>
        public string SupplyAccount
        {
            get { return _SupplyAccount; }
            set { _SupplyAccount = value; }
        }

        /// <summary>
        /// ���乫�������
        /// </summary>
        public decimal? SupplyBase
        {
            get { return _SupplyBase; }
            set { _SupplyBase = value; }
        }

        private string _SupplyBaseTemp;

        /// <summary>
        /// ���乫��������ݴ棬�����жϸ�ʽ
        /// </summary>
        public string SupplyBaseTemp
        {
            get { return _SupplyBaseTemp; }
            set { _SupplyBaseTemp = value; }
        }

        /// <summary>
        /// ���������
        /// </summary>
        public decimal? Base
        {
            get { return _Base; }
            set { _Base = value; }
        }

        /// <summary>
        /// ��������Ч����
        /// </summary>
        public DateTime? EffectiveYearMonth
        {
            get { return _EffectiveYearMonth; }
            set { _EffectiveYearMonth = value; }
        }

        /// <summary>
        /// �����ݴ��ʽδ����Ļ���
        /// </summary>
        public string BaseTemp
        {
            get { return _BaseTemp; }
            set { _BaseTemp = value; }
        }

        /// <summary>
        /// �����ݴ��ʽδ�������Ч����
        /// </summary>
        public List<string> EffectiveYearMonthTemp
        {
            get { return _EffectiveYearMonthTemp; }
            set { _EffectiveYearMonthTemp = value; }
        }

        #endregion

        /// <summary>
        /// �ж��籣�Ƿ�Ϳ�һ��
        /// </summary>
        public bool EqualsNull()
        {
            if (Base == null && string.IsNullOrEmpty(Account) && EffectiveYearMonth == null && SupplyBase == null &&
                string.IsNullOrEmpty(SupplyAccount))
            {
                return true;
            }
            return false;
        }


        public override bool Equals(object obj)
        {
            EmployeeAccumulationFund eaf = obj as EmployeeAccumulationFund;
            if (eaf == null)
            {
                return false;
            }
            else
            {
                if (eaf.Base.Equals(Base) &&
                    eaf.EffectiveYearMonth.Equals(EffectiveYearMonth) &&
                    eaf.Account.Equals(Account) && eaf.SupplyAccount.Equals(SupplyAccount) &&
                    eaf.SupplyBase.Equals(SupplyBase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}