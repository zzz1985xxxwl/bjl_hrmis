//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: EmployeeWelfare.cs
// Creater:  Xue.wenlong
// Date:  2008-12-23
// Resume:Ա������
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class EmployeeWelfare
    {
        private EmployeeSocialSecurity _SocialSecurity;
        private EmployeeAccumulationFund _AccumulationFund;
        private int _EmployeeWelfareID;
        private Account _Owner;
        public EmployeeWelfare(int employeeWelfareID, EmployeeSocialSecurity socialSecurity,
                               EmployeeAccumulationFund accumulationFund) : this(socialSecurity, accumulationFund)
        {
            _EmployeeWelfareID = employeeWelfareID;
        }

        public EmployeeWelfare(EmployeeSocialSecurity socialSecurity, EmployeeAccumulationFund accumulationFund)

        {
            _SocialSecurity = socialSecurity;
            _AccumulationFund = accumulationFund;
        }

        #region ����

        /// <summary>
        /// ID
        /// </summary>
        public int EmployeeWelfareID
        {
            get { return _EmployeeWelfareID; }
            set { _EmployeeWelfareID = value; }
        }

        /// <summary>
        /// Ա���籣��Ϣ
        /// </summary>
        public EmployeeSocialSecurity SocialSecurity
        {
            get { return _SocialSecurity; }
            set { _SocialSecurity = value; }
        }

        /// <summary>
        /// Ա��������
        /// </summary>
        public EmployeeAccumulationFund AccumulationFund
        {
            get { return _AccumulationFund; }
            set { _AccumulationFund = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public Account Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }
        #endregion

        public static decimal? ConvertToDecimal(object obj)
        {
            if (obj == null || obj == DBNull.Value || string.IsNullOrEmpty(obj.ToString()))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        public static string ConvertToString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// ���ڽ����ݿ�ȡ�������ݱ�Ϊ���ڸ�ʽ
        /// </summary>
        public static DateTime? ConvertToDateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value || string.IsNullOrEmpty(obj.ToString()))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(obj);
            }
        }

        /// <summary>
        /// ���ڽ����±�Ϊ���ڸ�ʽ
        /// </summary>
        public static DateTime? ConvertToDateTime(List<string> s)
        {
            if (s == null || s.Count == 0)
            {
                return null;
            }
            else if (s.Count != 2)
            {
                return null;
            }
            else if (string.IsNullOrEmpty(s[0]) && string.IsNullOrEmpty(s[1]))
            {
                return null;
            }
            else
            {
                return new DateTime(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]), 1);
            }
        }

        public static List<string> YearAndMonth(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                DateTime dt = Convert.ToDateTime(dateTime);
                return new List<string>(new string[2] {dt.Year.ToString(), dt.Month.ToString()});
            }
            else
            {
                return new List<string>(new string[2] {"", ""});
            }
        }

        public override bool Equals(object obj)
        {
            EmployeeWelfare employeeWelfare = obj as EmployeeWelfare;
            if (employeeWelfare == null)
            {
                if (SocialSecurity.EqualsNull() && AccumulationFund.EqualsNull())
                {
                    return true;
                }
            }
            else
            {
                if (SocialSecurity.Equals(employeeWelfare.SocialSecurity) &&
                    AccumulationFund.Equals(employeeWelfare.AccumulationFund))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �ո���
        /// </summary>
        /// <returns></returns>
        public static EmployeeWelfare EmptyWelfare()
        {
            EmployeeWelfare welfare;
            EmployeeSocialSecurity employeeSocialSecurity =
                new EmployeeSocialSecurity(SocialSecurityTypeEnum.Null, null, null, null, null, null);
            employeeSocialSecurity.BaseTemp = "";
            employeeSocialSecurity.YangLaoBaseTemp = "";
            employeeSocialSecurity.YiLiaoBaseTemp = "";
            employeeSocialSecurity.ShiYeBaseTemp = "";
            employeeSocialSecurity.EffectiveYearMonthTemp = new List<string>(new string[2] { "", "" });
            EmployeeAccumulationFund employeeAccumulationFund =
                new EmployeeAccumulationFund(string.Empty, null, null, string.Empty, null);
            employeeAccumulationFund.BaseTemp = "";
            employeeAccumulationFund.EffectiveYearMonthTemp = new List<string>(new string[2] { "", "" });
            employeeAccumulationFund.SupplyAccount = string.Empty;
            welfare =
                new EmployeeWelfare(employeeSocialSecurity, employeeAccumulationFund);
            return welfare;
        }

        /// <summary>
        /// һЩ��������
        /// </summary>
        public class ConstParemeter
        {
            public static readonly string Name = "����";
            public static readonly string SocialType = "�籣����";
            public static readonly string SocialBase = "�籣����";
            public static readonly string SocialYM = "�籣��Ч����";
            public static readonly string FundAccount = "�������ʺ�";
            public static readonly string FundBase = "���������";
            public static readonly string FundYM = "��������Ч����";
            public static readonly string SupplyAccount = "���乫�����ʺ�";
            public static readonly string SupplyBase = "���乫�������";
            public static readonly string YangLaoBase = "���Ͻɷѻ���";
            public static readonly string YiLiaoBase = "ҽ�ƽɷѻ���";
            public static readonly string ShiYeBase = "ʧҵ�ɷѻ���";
        }
    }
}