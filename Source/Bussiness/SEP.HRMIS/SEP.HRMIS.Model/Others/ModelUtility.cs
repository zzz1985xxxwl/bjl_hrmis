//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ModelUtility.cs
// ������: �ߺ�
// ��������: 2008-05-19
// ����: �������ó�ʼ��Model��Ϣ��Ĭ��ֵ
// ----------------------------------------------------------------
using System;
using System.Text.RegularExpressions;

namespace SEP.HRMIS.Model
{
    public static class ModelUtility
    {
        private const string _ErrorTime = "������Ŀ�ʼʱ�����ڽ���ʱ��";

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
        /// ����2��ʱ��֮��������������Ҫ���ڸ������ռ�������
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
        /// ������ʽ��֤mail�Ƿ�ϸ�
        /// </summary>
        public static bool IsGoodEmail(string email)
        {
            string emailPattern =
                @"^\w+([\.\-]\w+)*\@\w+([\.\-]\w+)*\.\w+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
