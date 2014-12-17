//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EducationExperience.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 教育和培训经历 
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 教育和培训经历
    /// </summary>
    [Serializable]
    public class EducationExperience : Experience
    {
        /// <summary>
        /// 教育和培训经历构造函数
        /// </summary>
        /// <param name="school"></param>
        /// <param name="experiencePeriod"></param>
        /// <param name="contect"></param>
        /// <param name="remark"></param>
        public EducationExperience(string school, string experiencePeriod, string contect, string remark)
            : base(school, experiencePeriod, contect, remark)
        {
        }
    }
}
