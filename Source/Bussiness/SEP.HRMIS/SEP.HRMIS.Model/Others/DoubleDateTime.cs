//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DoubleDateTime.cs
// 创建者: 倪豪
// 创建日期: 2008-05-20
// 概述: 描述了2个时间点，比如8:30~9:00就是一个DoubleTime实例
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class DoubleDateTime
    {
        private string _VaildStartTime;
        private string _VaildEndTime;

        public DoubleDateTime(string vaildStartTime, string vaildEndTime)
        {
            _VaildStartTime = vaildStartTime;
            _VaildEndTime = vaildEndTime;
        }

        public string VaildStartTime
        {
            get { return _VaildStartTime; }
            set { _VaildStartTime = value; }
        }

        public string VaildEndTime
        {
            get { return _VaildEndTime; }
            set { _VaildEndTime = value; }
        }
    }
}
