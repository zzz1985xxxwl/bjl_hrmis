//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeAccumulationFund.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:公积金
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

        #region 属性

        /// <summary>
        /// 公积金帐号
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// 补充公积金帐号
        /// </summary>
        public string SupplyAccount
        {
            get { return _SupplyAccount; }
            set { _SupplyAccount = value; }
        }

        /// <summary>
        /// 补充公积金基数
        /// </summary>
        public decimal? SupplyBase
        {
            get { return _SupplyBase; }
            set { _SupplyBase = value; }
        }

        private string _SupplyBaseTemp;

        /// <summary>
        /// 补充公积金基数暂存，用于判断格式
        /// </summary>
        public string SupplyBaseTemp
        {
            get { return _SupplyBaseTemp; }
            set { _SupplyBaseTemp = value; }
        }

        /// <summary>
        /// 公积金基数
        /// </summary>
        public decimal? Base
        {
            get { return _Base; }
            set { _Base = value; }
        }

        /// <summary>
        /// 公积金生效年月
        /// </summary>
        public DateTime? EffectiveYearMonth
        {
            get { return _EffectiveYearMonth; }
            set { _EffectiveYearMonth = value; }
        }

        /// <summary>
        /// 用于暂存格式未检验的基数
        /// </summary>
        public string BaseTemp
        {
            get { return _BaseTemp; }
            set { _BaseTemp = value; }
        }

        /// <summary>
        /// 用于暂存格式未检验的生效年月
        /// </summary>
        public List<string> EffectiveYearMonthTemp
        {
            get { return _EffectiveYearMonthTemp; }
            set { _EffectiveYearMonthTemp = value; }
        }

        #endregion

        /// <summary>
        /// 判断社保是否和空一致
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