//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeSocialSecurity.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:�籣
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

        #region ����

        /// <summary>
        /// �籣����
        /// </summary>
        public SocialSecurityTypeEnum Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// �籣����
        /// </summary>
        public decimal? Base
        {
            get { return _Base; }
            set { _Base = value; }
        }

        /// <summary>
        /// �籣��Ч����
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

        private string _YangLaoBaseTemp;
        /// <summary>
        /// ���Ͻɷѻ���,�����ݴ��ʽδ����Ļ���
        /// </summary>
        public string YangLaoBaseTemp
        {
            get { return _YangLaoBaseTemp; }
            set { _YangLaoBaseTemp = value; }
        }

        private string _ShiYeBaseTemp;
        /// <summary>
        /// ʧҵ�ɷѻ���,�����ݴ��ʽδ����Ļ���
        /// </summary>
        public string ShiYeBaseTemp
        {
            get { return _ShiYeBaseTemp; }
            set { _ShiYeBaseTemp = value; }
        }

        private string _YiLiaoBaseTemp;
        /// <summary>
        /// ҽ�ƽɷѻ���,�����ݴ��ʽδ����Ļ���
        /// </summary>
        public string YiLiaoBaseTemp
        {
            get { return _YiLiaoBaseTemp; }
            set { _YiLiaoBaseTemp = value; }
        }
        private decimal? _YangLaoBase;
        /// <summary>
        /// ���Ͻɷѻ���
        /// </summary>
        public decimal? YangLaoBase
        {
            get { return _YangLaoBase; }
            set { _YangLaoBase = value; }
        }

        private decimal? _ShiYeBase;
        /// <summary>
        /// ʧҵ�ɷѻ���
        /// </summary>
        public decimal? ShiYeBase
        {
            get { return _ShiYeBase; }
            set { _ShiYeBase = value; }
        }

        private decimal? _YiLiaoBase;
        /// <summary>
        /// ҽ�ƽɷѻ���
        /// </summary>
        public decimal? YiLiaoBase
        {
            get { return _YiLiaoBase; }
            set { _YiLiaoBase = value; }
        }
        #endregion

        /// <summary>
        /// �ж��籣�Ƿ�Ϳ�һ��
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