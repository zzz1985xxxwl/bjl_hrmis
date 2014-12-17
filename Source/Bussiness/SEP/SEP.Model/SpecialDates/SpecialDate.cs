//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: SpecialDate.cs
// 创建者: yyb
// 创建日期: 2009-03-10
// 概述: 记录特殊的工作非工作时间情况
// ----------------------------------------------------------------
using System;
namespace SEP.Model.SpecialDates
{
    [Serializable]
    public class SpecialDate
    {
        private int _SpecialDateID;
        private DateTime _SpecialDateTime;//特殊日期
        private int _IsWork;//是否工作,0不工作，1工作，2法定节假
        private string _SpecialHeader;//说明
        private string _SpecialDescription;//详细说明
        private string _SpecialForeColor;
        private string _SpecialBackColor;

        public SpecialDate()
        {
        }

        public SpecialDate(int specialDateID, DateTime specialDates, int isWork, string specialHeader,
            string specialDescription, string specialForeColor, string specialBackColor)
        {
            _SpecialDateID = specialDateID;
            _SpecialDateTime = specialDates;
            _IsWork = isWork;
            _SpecialHeader = specialHeader;
            _SpecialDescription = specialDescription;
            _SpecialForeColor = specialForeColor;
            _SpecialBackColor = specialBackColor;
        }

        /// <summary>
        /// 特殊日期ID
        /// </summary>
        public int SpecialDateID
        {
            get
            {
                return _SpecialDateID;
            }
            set
            {
                _SpecialDateID = value;
            }
        }

        /// <summary>
        /// 特殊日期,DateTime
        /// </summary>
        public DateTime SpecialDateTime
        {
            get
            {
                return _SpecialDateTime;
            }
            set
            {
                _SpecialDateTime = value;
            }
        }

        /// <summary>
        /// 是否工作,0不工作，1工作，2法定节假
        /// </summary>
        public int IsWork
        {
            get
            {
                return _IsWork;
            }
            set
            {
                _IsWork = value;
            }
        }

        /// <summary>
        /// 日历控件中对于一天的名称，如工作，休息，国庆节，中秋节
        /// </summary>
        public string SpecialHeader
        {
            get
            {
                return _SpecialHeader;
            }
            set
            {
                _SpecialHeader = value;
            }
        }

        /// <summary>
        /// 日历控件中对于一天的描述，如中秋节放假等
        /// </summary>
        public string SpecialDescription
        {
            get
            {
                return _SpecialDescription;
            }
            set
            {
                _SpecialDescription = value;
            }
        }

        /// <summary>
        /// 日历控件中对于一天的名称颜色，如：工作为绿色，休息为黑色
        /// </summary>
        public string SpecialForeColor
        {
            get
            {
                return _SpecialForeColor;
            }
            set
            {
                _SpecialForeColor = value;
            }
        }

        /// <summary>
        /// 日历控件中对于一天的背景颜色，如：这天工作，则背景为白色，休息则背景为红色
        /// </summary>
        public string SpecialBackColor
        {
            get
            {
                return _SpecialBackColor;
            }
            set
            {
                _SpecialBackColor = value;
            }
        }

    }
}
