//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: HRItem.cs
// 创建者: 倪豪
// 创建日期: 2008-05-29
// 概述: 人事填写项
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 人事填写项
    /// </summary>
    [Serializable]
    public class HRItem : AssessActivityItem
    {
        /// <summary>
        /// 人事填写项
        /// </summary>
        /// <param name="question"></param>
        /// <param name="option"></param>
        /// <param name="classfication"></param>
        /// <param name="description"></param>
        public HRItem(string question, string option, ItemClassficationEmnu classfication,string description)
            : base(question, option, classfication, description)
        {
            
        }
    }
}
