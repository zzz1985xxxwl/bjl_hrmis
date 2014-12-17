//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: Holiday.cs
// Creater:  Xue.wenlong
// Date:  2010-02-22
// Resume:
// ----------------------------------------------------------------

using System;

namespace SEP.Presenter.CalendarExt
{
    /// <summary>
    /// ֻ��Ҫȡ��������
    /// </summary>
    public class Holiday
    {
        private  DateTime _Date;
        private  string _Name;
        public Holiday(DateTime date,string name)
        {
            _Date = date;
            _Name = name;
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
        /// ����,�紺��
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
    }

}