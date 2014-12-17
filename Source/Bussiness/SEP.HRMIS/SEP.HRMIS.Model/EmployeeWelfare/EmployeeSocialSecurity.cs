//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeSocialSecurity.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:社保
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class EmployeeSocialSecurity
    {
        private SocialSecurityTypeEnum _Type;
        private decimal? _Base;
        private DateTime? _EffectiveYearMonth;
        private string _BaseTemp;
        private List<string> _EffectiveYearMonthTemp;
        public EmployeeSocialSecurity(SocialSecurityTypeEnum type, decimal? baseNum, DateTime? effectiveYearMonth,
             decimal? yangLaoBase, decimal? shiYeBase, decimal? yiLiaoBase)
        {
            _YangLaoBase = yangLaoBase;
            _YiLiaoBase = yiLiaoBase;
            _ShiYeBase = shiYeBase;
            _Type = type;
            _Base = baseNum;
            _EffectiveYearMonth = effectiveYearMonth;
        }

        #region 属性

        /// <summary>
        /// 社保类型
        /// </summary>
        public SocialSecurityTypeEnum Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// 社保基数
        /// </summary>
        public decimal? Base
        {
            get { return _Base; }
            set { _Base = value; }
        }

        /// <summary>
        /// 社保生效年月
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

        private string _YangLaoBaseTemp;
        /// <summary>
        /// 养老缴费基数,用于暂存格式未检验的基数
        /// </summary>
        public string YangLaoBaseTemp
        {
            get { return _YangLaoBaseTemp; }
            set { _YangLaoBaseTemp = value; }
        }

        private string _ShiYeBaseTemp;
        /// <summary>
        /// 失业缴费基数,用于暂存格式未检验的基数
        /// </summary>
        public string ShiYeBaseTemp
        {
            get { return _ShiYeBaseTemp; }
            set { _ShiYeBaseTemp = value; }
        }

        private string _YiLiaoBaseTemp;
        /// <summary>
        /// 医疗缴费基数,用于暂存格式未检验的基数
        /// </summary>
        public string YiLiaoBaseTemp
        {
            get { return _YiLiaoBaseTemp; }
            set { _YiLiaoBaseTemp = value; }
        }
        private decimal? _YangLaoBase;
        /// <summary>
        /// 养老缴费基数
        /// </summary>
        public decimal? YangLaoBase
        {
            get { return _YangLaoBase; }
            set { _YangLaoBase = value; }
        }

        private decimal? _ShiYeBase;
        /// <summary>
        /// 失业缴费基数
        /// </summary>
        public decimal? ShiYeBase
        {
            get { return _ShiYeBase; }
            set { _ShiYeBase = value; }
        }

        private decimal? _YiLiaoBase;
        /// <summary>
        /// 医疗缴费基数
        /// </summary>
        public decimal? YiLiaoBase
        {
            get { return _YiLiaoBase; }
            set { _YiLiaoBase = value; }
        }
        #endregion

        /// <summary>
        /// 判断社保是否和空一致
        /// </summary>
        public bool EqualsNull()
        {
            if (Base == null && Type.Id == 0 && EffectiveYearMonth == null
                && YangLaoBase == null && ShiYeBase == null && YiLiaoBase == null)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            EmployeeSocialSecurity ess = obj as EmployeeSocialSecurity;
            if (ess == null)
            {
                return false;
            }
            else
            {
                if (ess.Base.Equals(Base) &&
                    ess.YangLaoBase.Equals(YangLaoBase) &&
                    ess.ShiYeBase.Equals(ShiYeBase) &&
                    ess.YiLiaoBase.Equals(YiLiaoBase) &&
                    ess.EffectiveYearMonth.Equals(EffectiveYearMonth) &&
                    ess.Type.Id.Equals(Type.Id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}