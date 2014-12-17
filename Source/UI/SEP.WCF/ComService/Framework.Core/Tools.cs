using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Core
{
    public static class Tools
    {
        private const string Regex_az = @"^[A-Za-z]+$";//ƥ����26��Ӣ����ĸ��ɵ��ַ���
        private const string Regex_chs = @"[\u4e00-\u9fa5]";//ƥ�������ַ���������ʽ
        private const string Regex_PhoneNum = @"(^(\d{2,4}[-_����]?)?\d{3,8}([-_����]?\d{3,8})?([-_����]?\d{1,7})?$)|(^0?1[35]\d{9}$)";//�绰����������ʽ
        private const string Regex_Email = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";//Email������ʽ
        private const string Regex_URL = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//URL������ʽ

        /// <summary>
        /// �Ƿ�Ϊ��26��Ӣ����ĸ��ɵ��ַ���
        /// </summary>
        public static bool IsAz(string str)
        {
            return RegexMatch(Regex_az, str);
        }

        /// <summary>
        /// �Ƿ�Ϊ�����ַ�
        /// </summary>
        public static bool IsCHS(string str)
        {
            return RegexMatch(Regex_chs, str);
        }

        /// <summary>
        /// �Ƿ�Ϊ�绰����
        /// </summary>
        public static bool IsPhoneNum(string str)
        {
            return RegexMatch(Regex_PhoneNum, str);
        }


        /// <summary>
        /// �Ƿ�ΪEmail��ַ
        /// </summary>
        public static bool IsEmail(string str)
        {
            return RegexMatch(Regex_Email, str) && !RegexMatch(Regex_chs, str);
        }


        /// <summary>
        /// �Ƿ�ΪURL
        /// </summary>
        public static bool IsURL(string str)
        {
            return RegexMatch(Regex_URL, str);
        }

        private static bool RegexMatch(string pattern, string str)
        {
            Regex rx = new Regex(pattern);
            return rx.IsMatch(str);
        }
    }
}
