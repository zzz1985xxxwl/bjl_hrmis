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
    /// �����е�ÿһ��
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
        /// ��������������ʾ���磺���(�ύ)8H
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        /// <summary>
        /// ��������������ϸ��������ʾ
        /// </summary>
        public string Detail
        {
            set { _Detail = value; }
            get { return _Detail; }
        }

        /// <summary>
        /// ��һ��
        /// </summary>
        public DateTime Date
        {
            set { _Date = value; }
            get { return _Date; }
        }

        /// <summary>
        /// �����У�ÿһ��ı�����ɫ��Ĭ�ϰ�ɫ�������������Ϣʱ��������ɫ�ı�
        /// </summary>
        public string BackgroundColor
        {
            get { return _BackgroundColor; }
            set { _BackgroundColor = value; }
        }

        /// <summary>
        /// ���ͣ���������Ӱ࣬���Ҵ��н�ȡ�����͵���ɫ�����ڽ�����ʾ�����ƽ�������С�����У�id���ڴ�ȡ���ж�����
        /// </summary>
        public CalendarShowType CType
        {
            get { return _CType; }
            set { _CType = value; }
        }
    }
}