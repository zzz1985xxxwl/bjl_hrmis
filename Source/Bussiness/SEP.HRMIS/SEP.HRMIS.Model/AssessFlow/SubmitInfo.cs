//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CommitInfo.cs
// 创建者: 倪豪
// 创建日期: 2008-05-29
// 概述: 考评表填写的信息
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 考评表填写的信息
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
        /// 考评表填写的信息
        /// </summary>
        public SubmitInfo()
        {
            SetDefaultValue();
        }

        /// <summary>
        /// 考评表填写的信息 操作人姓名
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
        /// 考评表填写的信息 提交时间
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
        /// 考评表填写的信息 备注
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
        /// 类型
        /// </summary>
        public SubmitInfoType SubmitInfoType
        {
            get { return _SubmitInfoType; }
            set { _SubmitInfoType = value; }
        }

        /// <summary>
        /// 自定义流程的步骤的index
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
        /// 考评流程中项的业务模型
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
        /// 编号
        /// </summary>
        public int SubmitInfoID
        {
            get { return _SubmitInfoID; }
            set { _SubmitInfoID = value; }
        }
        /// <summary>
        /// 现在工资
        /// </summary>
        public decimal? SalaryNow
        {
            get { return _SalaryNow; }
            set { _SalaryNow = value; }
        }
        /// <summary>
        /// 期望工资
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
