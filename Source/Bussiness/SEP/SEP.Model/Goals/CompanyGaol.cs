//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: CompanyGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公司目标
// ----------------------------------------------------------------
using System;


namespace SEP.Model.Goals
{
    /// <summary>
    /// 公司目标
    /// </summary>
    [Serializable]
    public class CompanyGoal : Goal
    {
        public CompanyGoal(int id, string title, string content, 
            DateTime setTime)
            : base(id, title, content, setTime)
        {
        }
    }
}
