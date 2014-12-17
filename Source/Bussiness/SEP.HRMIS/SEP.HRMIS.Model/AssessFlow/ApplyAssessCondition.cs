//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ApplyAssessCondition.cs
// ������: wang.shali 
// ��������: 2008-07-24
// ����: ��¼�Զ�����������
// ----------------------------------------------------------------
using System;
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��¼�Զ�����������
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
        /// �Զ�����������
        /// </summary>
        /// <param name="_conditionID"></param>
        public ApplyAssessCondition(int _conditionID)
        {
            _ConditionID = _conditionID;
        }
        /// <summary>
        /// Ա����ͬID
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
        /// ����PKID
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
        /// ����������
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
        /// ����ʱ��
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
        /// ������Χ��ʼʱ��
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
        /// ������Χ����ʱ��
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
