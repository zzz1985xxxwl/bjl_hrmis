//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MonthItem.cs
// Creater:  Xue.wenlong
// Date:  2010-02-22
// Resume:
// ----------------------------------------------------------------

using System;

namespace SEP.Model.CalendarExt
{
    /// <summary>
    /// 日历中的每一项
    /// </summary>
    public class MonthItem
    {
        private int _ObjectID;
        private string _Detail;
        private string _Title;
        private DateTime _Date;
        private string _BackgroundColor;
        private CalendarShowType _CType;

        public MonthItem(string title, string detail, DateTime date, CalendarShowType type, string backgroundColor)
            : this(title, detail, date, type)
        {
            _BackgroundColor = backgroundColor;
        }

        public MonthItem(string title, string detail, DateTime date, CalendarShowType type)
        {
            _Detail = detail;
            _Title = title;
            _Date = date;
            _CType = type;
        }

        public MonthItem()
        {
        }

        public int ObjectID
        {
            set { _ObjectID = value; }
            get { return _ObjectID; }
            
        }
        /// <summary>
        /// 用于在月历中显示，如：外出(提交)8H
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        /// <summary>
        /// 用于在月历的详细界面中显示
        /// </summary>
        public string Detail
        {
            set { _Detail = value; }
            get { return _Detail; }
        }

        /// <summary>
        /// 哪一天
        /// </summary>
        public DateTime Date
        {
            set { _Date = value; }
            get { return _Date; }
        }

        /// <summary>
        /// 日历中，每一天的背景颜色，默认白色，但如果遇到休息时，背景颜色改变
        /// </summary>
        public string BackgroundColor
        {
            get { return _BackgroundColor; }
            set { _BackgroundColor = value; }
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