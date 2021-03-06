//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalItem.cs
// 创建者: 倪豪
// 创建日期: 2008-05-29
// 概述: 员工填写项
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工填写项
    /// </summary>
    [Serializable]
    public class PersonalItem : AssessActivityItem
    {
        /// <summary>
        /// 员工填写项
        /// </summary>
        /// <param name="question"></param>
        /// <param name="option"></param>
        /// <param name="classfication"></param>
        /// <param name="description"></param>
        public PersonalItem(string question, string option, ItemClassficationEmnu classfication, string description)
            : base(question, option, classfication, description)
        {
        }
    }
}
