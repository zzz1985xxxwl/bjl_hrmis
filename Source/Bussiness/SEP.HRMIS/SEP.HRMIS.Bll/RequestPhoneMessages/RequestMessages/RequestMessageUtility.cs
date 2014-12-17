//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: RequestMessageUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-05-31
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.RequestMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestMessageUtility
    {
        /// <summary>
        /// 把如200809170900的字符串转换为时间格式，如果转换是否则返回null
        /// </summary>
        public static DateTime? GetDateTime(string str)
        {
            DateTime? dt;
            try
            {
                dt = new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)),
                                  Convert.ToInt32(str.Substring(6, 2)), Convert.ToInt32(str.Substring(8, 2)),
                                  Convert.ToInt32(str.Substring(10, 2)), 00);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
        /// <summary>
        /// 把如“请假 外出  辅导课”的字符串，通过空格将其划分（当中的空格数可以任意），如果该字符串为空，则返回null
        /// </summary>
        public static List<string> GetElement(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                List<string> slist = new List<string>();
                foreach (string s in str.Split(' '))
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        slist.Add(s);
                    }
                }
                return slist;
            }
            return null;
        }
    }
}