//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Contract.cs
// 创建者: yyb
// 创建日期: 2008-05-12
// 概述: 员工合同
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工合同
    /// </summary>
    [Serializable]
    public class Contract
    {
        #region 私有变量
        private int _ContractID;
        private int _EmployeeID;
        private string _EmployeeName;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private ContractType _ContractType;
        private List<ApplyAssessCondition> _ApplyAssessConditions;
        private string _Remark;
        private string _Attachment;
        private List<EmployeeContractBookMark> _EmployeeContractBookMark;
        private Employee _Employee;
        #endregion

        #region 构造函数
        /// <summary>
        /// 员工合同
        /// </summary>
        public Contract() { }
        /// <summary>
        /// 员工合同
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="contractType"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public Contract(int contractID, ContractType contractType, DateTime startDate, DateTime endDate)
        {
            _ContractID = contractID;
            _ContractType = contractType;
            _StartDate = startDate;
            _EndDate = endDate;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 合同ID
        /// </summary>
        public int ContractID
        {
            get
            {
                return _ContractID;
            }
            set
            {
                _ContractID = value;
            }
        }
        /// <summary>
        /// 员工
        /// </summary>
        public Employee Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                _Employee = value;
            }
        }
        /// <summary>
        /// 员工帐号ID
        /// </summary>
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }
        /// <summary>
        /// 合同类型
        /// </summary>
        public ContractType ContractType
        {
            get
            {
                return _ContractType;
            }
            set
            {
                _ContractType = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }
        /// <summary>
        /// 合同附件
        /// </summary>
        public string Attachment
        {
            get
            {
                return _Attachment;
            }
            set
            {
                _Attachment = value;
            }
        }
        /// <summary>
        /// 合同标签
        /// </summary>
        public List<EmployeeContractBookMark> EmployeeContractBookMark
        {
            get
            {
                return _EmployeeContractBookMark;
            }
            set
            {
                _EmployeeContractBookMark = value;
            }
        }
        /// <summary>
        /// 合同发起考评
        /// </summary>
        public List<ApplyAssessCondition> ApplyAssessConditions
        {
            get
            {
                return _ApplyAssessConditions;
            }
            set
            {
                _ApplyAssessConditions = value;
            }
        }

        private string _CompanyName;
        /// <summary>
        /// 所属公司 add by liudan 2009-10-21
        /// </summary>
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }
        #endregion

        #region 方法

        public bool Equals(Contract obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.ContractID == _ContractID &&
                   Equals(obj.Attachment, _Attachment) &&
                   Equals(obj.ContractType.ContractTypeID, _ContractType.ContractTypeID) &&
                   Equals(obj.ContractType.ContractTypeName, _ContractType.ContractTypeName) &&
                   Equals(obj._EmployeeID, _EmployeeID) &&
                   Equals(obj._EmployeeName, _EmployeeName) &&
                   Equals(obj._EndDate, _EndDate) &&
                   Equals(obj._Remark, _Remark) &&
                   Equals(obj._StartDate, _StartDate);
        }
        /// <summary>
        /// hashcode
        /// </summary>
        public int HashCode
        {
            get
            {
                unchecked
                {
                    int result = _EmployeeID;
                    result = (result * 397) ^ (Attachment != null ? Attachment.GetHashCode() : 0);
                    result = (result * 397) ^ (_Remark != null ? _Remark.GetHashCode() : 0);
                    result = (result * 397) ^ (_ContractType != null ? _ContractType.GetHashCode() : 0);
                    return result;
                }
            }
        }
        /// <summary>
        /// 为导出
        /// </summary>
        /// <returns></returns>
        public string StatContract()
        {
            StringBuilder theContract = new StringBuilder();
            theContract.Append(_ContractID).Append("\t").Append(_EmployeeID).Append("\t").Append(_EmployeeName).Append("\t").Append(_StartDate.ToShortDateString()).Append("\t")
                .Append(_EndDate.ToShortDateString()).Append("\t").Append(_ContractType == null ? "" : _ContractType.ContractTypeName).Append("\t").Append(string.IsNullOrEmpty(_Remark) ? "" : _Remark.Replace("\r\n", "")).Append("\t").Append(string.IsNullOrEmpty(_Attachment) ? "" : _Attachment.Replace("\r\n", "")).Append("\t");

            return theContract.ToString();
        }
        #endregion
    }
}