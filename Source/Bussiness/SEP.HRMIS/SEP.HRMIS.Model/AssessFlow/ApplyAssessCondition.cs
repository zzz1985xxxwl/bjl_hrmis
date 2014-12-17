//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ApplyAssessCondition.cs
// 创建者: wang.shali 
// 创建日期: 2008-07-24
// 概述: 记录自动发起考评条件
// ----------------------------------------------------------------
using System;
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 记录自动发起考评条件
    /// </summary>
    [Serializable]
    public class ApplyAssessCondition
    {
        private int _ConditionID;
        private int _EmployeeContractID;
        private DateTime _ApplyDate;
        private AssessCharacterType _ApplyAssessCharacterType;
        private DateTime _AssessScopeFrom;
        private DateTime _AssessScopeTo;
        /// <summary>
        /// 自动发起考评条件
        /// </summary>
        /// <param name="_conditionID"></param>
        public ApplyAssessCondition(int _conditionID)
        {
            _ConditionID = _conditionID;
        }
        /// <summary>
        /// 员工合同ID
        /// </summary>
        public int EmployeeContractID
        {
            get
            {
                return _EmployeeContractID;
            }
            set
            {
                _EmployeeContractID = value;
            }
        }
        /// <summary>
        /// 条件PKID
        /// </summary>
        public int ConditionID
        {
            get
            {
                return _ConditionID;
            }
            set
            {
                _ConditionID = value;
            }
        }
        /// <summary>
        /// 发起考评类型
        /// </summary>
        public AssessCharacterType ApplyAssessCharacterType
        {
            get
            {
                return _ApplyAssessCharacterType;
            }
            set
            {
                _ApplyAssessCharacterType = value;
            }
        }
        /// <summary>
        /// 发起时间
        /// </summary>
        public DateTime ApplyDate
        {
            get
            {
                return _ApplyDate;
            }
            set
            {
                _ApplyDate = value;
            }
        }
        /// <summary>
        /// 考评范围开始时间
        /// </summary>
        public DateTime AssessScopeFrom
        {
            get
            {
                return _AssessScopeFrom;
            }
            set
            {
                _AssessScopeFrom = value;
            }
        }
        /// <summary>
        /// 考评范围结束时间
        /// </summary>
        public DateTime AssessScopeTo
        {
            get
            {
                return _AssessScopeTo;
            }
            set
            {
                _AssessScopeTo = value;
            }
        }
    }
}
