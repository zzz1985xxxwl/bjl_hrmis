using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Core
{
    public static class Tools
    {
        private const string Regex_az = @"^[A-Za-z]+$";//匹配由26个英文字母组成的字符串
        private const string Regex_chs = @"[\u4e00-\u9fa5]";//匹配中文字符的正则表达式
        private const string Regex_PhoneNum = @"(^(\d{2,4}[-_－—]?)?\d{3,8}([-_－—]?\d{3,8})?([-_－—]?\d{1,7})?$)|(^0?1[35]\d{9}$)";//电话号码正则表达式
        private const string Regex_Email = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";//Email正则表达式
        private const string Regex_URL = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//URL正则表达式

        /// <summary>
        /// 是否为由26个英文字母组成的字符串
        /// </summary>
        public static bool IsAz(string str)
        {
            return RegexMatch(Regex_az, str);
        }

        /// <summary>
        /// 是否为中文字符
        /// </summary>
        public static bool IsCHS(string str)
        {
            return RegexMatch(Regex_chs, str);
        }

        /// <summary>
        /// 是否为电话号码
        /// </summary>
        public static bool IsPhoneNum(string str)
        {
            return RegexMatch(Regex_PhoneNum, str);
        }


        /// <summary>
        /// 是否为Email地址
        /// </summary>
        public static bool IsEmail(string str)
        {
            return RegexMatch(Regex_Email, str) && !RegexMatch(Regex_chs, str);
        }


        /// <summary>
        /// 是否为URL
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
