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
        /// ��¼��ض����PKID
        /// </summary>
        public int ObjectID
        {
            set { _ObjectID = value; }
            get { return _ObjectID; }
        }
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime Start
        {
            get { return _Start; }
            set { _Start = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime End
        {
            get { return _End; }
            set { _End = value; }
        }

        /// <summary>
        /// ������ʾ����ͼ�е�����,��:���12:00��14:00<br /> ������ɣ�<br /> XXXXXXXX
        /// </summary>
        public string DayDetail
        {
            get { return _DayDetail; }
            set { _DayDetail = value; }
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