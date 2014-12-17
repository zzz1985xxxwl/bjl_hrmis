//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessActivityItem.cs
// 创建者: 倪豪
// 创建日期: 2008-05-29
// 概述: 考评流程中项的业务模型
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 考评流程中项的业务模型
    /// </summary>
    [Serializable]
    public class AssessActivityItem
    {
        private decimal _Grade;
        private string _Note;
        private string _Question;
        private string _Option;
        private ItemClassficationEmnu _Classfication;
        private string _Description;
        private AssessTemplateItemType _AssessTemplateItemType;
        private decimal _Weight;
        private AssessActivityItemType _AssessActivityItemType;

        /// <summary>
        /// 考评流程中项的业务模型
        /// </summary>
        /// <param name="question"></param>
        /// <param name="option"></param>
        /// <param name="classfication"></param>
        /// <param name="description"></param>
        public AssessActivityItem(string question, string option, ItemClassficationEmnu classfication, string description)
        {
            _Question = question;
            _Option = option;
            _Classfication = classfication;
            _Description = description;

            SetDefaultValue();
        }

        public string Question
        {
            get
            {
                return _Question;
            }
            set
            {
                _Question = value;
            }
        }

        public decimal Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
            }
        }

        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }

        public string Option
        {
            get
            {
                return _Option;
            }
            set
            {
                _Option = value;
            }
        }
        /// <summary>
        /// 绩效，能力，品德，学识，态度，其它
        /// </summary>
        public ItemClassficationEmnu Classfication
        {
            get
            {
                return _Classfication;
            }
            set
            {
                _Classfication = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private string _GradeString;
        /// <summary>
        /// 用于暂存grad
        /// </summary>
        public string GradeString
        {
            get
            {
                return _GradeString;
            }
            set
            {
                _GradeString = value;
            } 
        }

        /// <summary>
        /// 开发，打分，选择，公式
        /// </summary>
        public AssessTemplateItemType AssessTemplateItemType
        {
            get { return _AssessTemplateItemType; }
            set { _AssessTemplateItemType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        /// <summary>
        /// 考评项类型,人事项，个人，主管
        /// </summary>
        public AssessActivityItemType AssessActivityItemType
        {
            get { return _AssessActivityItemType; }
            set { _AssessActivityItemType = value; }
        }

        private void SetDefaultValue()
        {
            _Grade = ModelUtility.MakeDefaultInt();
            _Note = ModelUtility.MakeDefaultString();
        }
    }
}
