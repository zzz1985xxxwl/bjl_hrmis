//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CommitInfo.cs
// ������: �ߺ�
// ��������: 2008-05-29
// ����: ��������д����Ϣ
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������д����Ϣ
    /// </summary>
    [Serializable]
    public class SubmitInfo
    {
        private int _SubmitInfoID;
        private string _FillPerson;
        private DateTime _SubmitTime;
        private string _Comment;
        private SubmitInfoType _SubmitInfoType;
        private int _StepIndex;
        private string _Choose;
        private decimal? _SalaryNow;
        private decimal? _SalaryChange;
        private List<AssessActivityItem> _assessActivityItems = new List<AssessActivityItem>();

        /// <summary>
        /// ��������д����Ϣ
        /// </summary>
        public SubmitInfo()
        {
            SetDefaultValue();
        }

        /// <summary>
        /// ��������д����Ϣ ����������
        /// </summary>
        public string FillPerson
        {
            get
            {
                return _FillPerson;
            }
            set
            {
                _FillPerson = value;
            }
        }

        /// <summary>
        /// ��������д����Ϣ �ύʱ��
        /// </summary>
        public DateTime SubmitTime
        {
            get
            {
                return _SubmitTime;
            }
            set
            {
                _SubmitTime = value;
            }
        }

        /// <summary>
        /// ��������д����Ϣ ��ע
        /// </summary>
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                _Comment = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public SubmitInfoType SubmitInfoType
        {
            get { return _SubmitInfoType; }
            set { _SubmitInfoType = value; }
        }

        /// <summary>
        /// �Զ������̵Ĳ����index
        /// </summary>
        public int StepIndex
        {
            get { return _StepIndex; }
            set { _StepIndex = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Choose
        {
            get
            {
                return _Choose;
            }
            set
            {
                _Choose = value;
            }
        }

        /// <summary>
        /// �������������ҵ��ģ��
        /// </summary>
        public List<AssessActivityItem> ItsAssessActivityItems
        {
            get
            {
                return _assessActivityItems;
            }
            set
            {
                _assessActivityItems = value;
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        public int SubmitInfoID
        {
            get { return _SubmitInfoID; }
            set { _SubmitInfoID = value; }
        }
        /// <summary>
        /// ���ڹ���
        /// </summary>
        public decimal? SalaryNow
        {
            get { return _SalaryNow; }
            set { _SalaryNow = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public decimal? SalaryChange
        {
            get { return _SalaryChange; }
            set { _SalaryChange = value; }
        }

        public int AssessActivityID { get; set; }
        private void SetDefaultValue()
        {
            _FillPerson = ModelUtility.MakeDefaultString();
            _SubmitTime = ModelUtility.MakeDefaultTime();
            _Comment = ModelUtility.MakeDefaultString();
            _Choose = ModelUtility.MakeDefaultString();
        }
    }
}
