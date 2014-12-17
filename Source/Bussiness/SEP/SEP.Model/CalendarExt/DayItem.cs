//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DayItem.cs
// Creater:  Xue.wenlong
// Date:  2010-02-22
// Resume:
// ----------------------------------------------------------------

using System;

namespace SEP.Model.CalendarExt
{
    public class DayItem
    {
        private int _ObjectID;
        private DateTime _Start;
        private DateTime _End;
        private string _DayDetail;
        private CalendarShowType _CType;

        public DayItem(DateTime start, DateTime end, string detail, CalendarShowType type)
        {
            _Start = start;
            _End = end;
            _DayDetail = detail;
            _CType = type;
        }

        public DayItem()
        {
        }

        /// <summary>
        /// 记录相关对象的PKID
        /// </summary>
        public int ObjectID
        {
            set { _ObjectID = value; }
            get { return _ObjectID; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Start
        {
            get { return _Start; }
            set { _Start = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End
        {
            get { return _End; }
            set { _End = value; }
        }

        /// <summary>
        /// 用于显示日视图中的内容,如:年假12:00到14:00<br /> 请假理由：<br /> XXXXXXXX
        /// </summary>
        public string DayDetail
        {
            get { return _DayDetail; }
            set { _DayDetail = value; }
        }

        /// <summary>
        /// 类型，如外出，加班，并且从中将取出类型的颜色，用于界面显示，名称将被用在小界面中，id用于存取或判断类型
        /// </summary>
        public CalendarShowType CType
        {
            get { return _CType; }
            set { _CType = value; }
        }
    }
}