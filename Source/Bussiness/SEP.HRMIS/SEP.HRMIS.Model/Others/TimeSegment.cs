//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TimeSegment.cs
// 创建者: 倪豪
// 创建日期: 2008-08-05
// 概述: 时间段：如 startTime 8:00~8:30 endTime 4:30~5:30就是一个时间段
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class TimeSegment
    {
        private DoubleDateTime _StartTime;
        private DoubleDateTime _EndTime;
        private bool _Enable;

        public TimeSegment(DoubleDateTime startTime, DoubleDateTime endTime)
        {
            _StartTime = startTime;
            _EndTime = endTime;
        }

        public DoubleDateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        public DoubleDateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }

        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }
    }
}
