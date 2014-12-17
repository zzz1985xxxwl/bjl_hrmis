//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WorkExperience.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 工作经历
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 工作经历
    /// </summary>
    [Serializable]
    public class WorkExperience : Experience
    {
        private string _ContactPerson;
        /// <summary>
        /// 工作经历列表
        /// </summary>
        /// <param name="company"></param>
        /// <param name="experiencePeriod"></param>
        /// <param name="content"></param>
        /// <param name="remark"></param>
        /// <param name="contactPerson"></param>
        public WorkExperience(string company, string experiencePeriod, string content, string remark,string contactPerson)
            : base(company, experiencePeriod, content, remark)
        {
            _ContactPerson = contactPerson;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson
        {
            get { return _ContactPerson; }
            set { _ContactPerson = value; }
        }
    }
}