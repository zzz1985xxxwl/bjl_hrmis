//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SocWorkAgeAndVacationList.cs
// 创建者: 王玥琦
// 创建日期: 2008-12-15
// 概述: 社会工龄与年假列表
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 社会工龄与年假列表
    /// </summary>
    [Serializable]
    public class SocWorkAgeAndVacationList
    {
        private int _SocietyWorkAge;
        private List<Vacation> _EmployeeVacations;

        /// <summary>
        /// 社会工龄
        /// </summary>
        public int SocietyWorkAge
        {
            get { return _SocietyWorkAge; }
            set { _SocietyWorkAge = value; }
        }
        /// <summary>
        /// 年假列表
        /// </summary>
        public List<Vacation> EmployeeVacations
        {
            get { return _EmployeeVacations; }
            set { _EmployeeVacations = value; }
        }
    }
}
