//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayRule.cs
// 创建者: 倪豪
// 创建日期: 2008-05-20
// 概述: 每一天的业务规则,可以有多个时间段，例如可以分时间段为上午、下午
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class DayRule
    {
        private string _Name;
        private List<TimeSegment> _TimeSegments = new List<TimeSegment>();

        public DayRule(string name,List<TimeSegment> timeSegments)
        {
            _Name = name;
            _TimeSegments = timeSegments;
        }

        public List<TimeSegment> TimeSegments
        {
            get { return _TimeSegments; }
            set { _TimeSegments = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
