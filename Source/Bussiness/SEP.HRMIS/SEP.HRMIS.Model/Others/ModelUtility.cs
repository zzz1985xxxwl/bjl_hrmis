//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ModelUtility.cs
// 创建者: 倪豪
// 创建日期: 2008-05-19
// 概述: 用于设置初始化Model信息的默认值
// ----------------------------------------------------------------
using System;
using System.Text.RegularExpressions;

namespace SEP.HRMIS.Model
{
    public static class ModelUtility
    {
        private const string _ErrorTime = "待计算的开始时间晚于结束时间";

        public static DateTime MakeDefaultTime()
        {
            return new DateTime(1900, 1, 1);
        }

        public static string MakeDefaultString()
        {
            return string.Empty;
        }

        public static int MakeDefaultInt()
        {
            return 0;
        }

        public static decimal MakeDefaultDecimal()
        {
            return 0m;
        }

        /// <summary>
        /// 计算2个时间之间的相隔年数，主要用于根据生日计算年龄
        /// </summary>
        public static int CalculateYearsBetween(DateTime startTime, DateTime endTime)
        {
            if (DateTime.Compare(startTime, endTime) > 0)
                throw new ApplicationException(_ErrorTime);

            int year = endTime.Year - startTime.Year;
            if (startTime.Month > endTime.Month)
            {
                year--;
            }
            else
            {
                if (startTime.Month == endTime.Month)
                {
                    if (startTime.Day > endTime.Day)
                    {
                        year--;
                    }
                }
            }
            return year;
        }

        /// <summary>
        /// 正则表达式验证mail是否合格
        /// </summary>
        public static bool IsGoodEmail(string email)
        {
            string emailPattern =
                @"^\w+([\.\-]\w+)*\@\w+([\.\-]\w+)*\.\w+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
