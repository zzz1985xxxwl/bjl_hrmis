//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: TeamGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 团队目标
// ----------------------------------------------------------------
using System;
using SEP.Model.Departments;

namespace SEP.Model.Goals
{
    /// <summary>
    /// 团队目标
    /// </summary>
    [Serializable]
    public class TeamGoal : Goal
    {
        private Department _Dept;
        public Department Dept
        {
            get
            {
                return _Dept;
            }
            set
            {
                _Dept = value;
            }
        }

        public TeamGoal(int id, string title, string content, DateTime setTime,
            Department department)
            : base(id, title, content, setTime)
        {
            _Dept = department;
        }
    }
}