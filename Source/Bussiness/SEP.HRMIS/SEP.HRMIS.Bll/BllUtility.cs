//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: BllUtility.cs
// ������: �ߺ�
// ��������: 2008-05-19
// ����: ������ResourceManager��ȡָ���ַ����׳��쳣�Ĺ���
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    public static class BllUtility
    {
        public const string _SmtpClient = "_SmtpClient";
        public const string _EmptyMailAddress = "empty@mailAddress.com";
        public const string _ResidenceString = @"���ڣ�������Ч����ǰ60��֮����ԭ��������������롣

�������̣�

 

1����½21�����˲��������롶������Ա�Ϻ��о�ס֤������ҵ��

 <http://www.21cnhr.gov.cn/> http://www.21cnhr.gov.cn

2�����ø��������½���û��������֤���룬��ʼ����111111��

3������ϸ��д�걨��Ϣ�����ύ���޷��޸ģ���������ѡ�����죩

4��������ύ������֪��˾������Դ����

5��׼��������ϣ�������¼�����˾������Դ����

6������Я���������ȥ�������

7����½��վ��ѯ��˽����

8���յ�����֪ͨ����뽫��ӡ�������¾ֵ���Ҫ������ת������˾�������ϲ�

 

�ο����ϣ� 

������ϣ�������ǩ��Ա������Ϣδ�����仯�ģ�

����1���������˲ţ��Ϻ��о�ס֤�����������Ӹ�Ƹ�õ�λ���£����������� 

����2����ס֤�����֤��ӡ����

3����ס֤��Ч�������һ����ڻ�����������˰֤����ӡ������ԭ����

4����ס֤��Ч�������һ����ڻ����ϱ���֤�������Ե��Ϻ����Ͷ�����ᱣ�Ͼֵ���վ <http://www.12333.com.cn/>  http://www.12333sh.gov.cn��ӡ���ɵ�λ�Ӹǹ���,ע���������������֤���룩��
��֮ǰδ��ͨ���籣���룬�뵽�ͽ����籣����ȥ��������,�����Ϳɰ���.Ҫ�����֤����ס֤ԭ����




������ǩ����Ա�������Ϣ�����仯�ģ�Ӧ�ṩ��ز���

����1����λ�仯�ģ��ṩ�µ�λ����֯��������֤��Ӫҵִ�գ���ҵ��λ����֤�飩���Ͷ���Ƹ�ã���ͬ���������϶���Ҫ�ṩԭ������ӡ�����µ�λ����Ϲ��ڵ�λ���������Ĺ涨��

����2��ԭ�Ͷ���Ƹ�ã���ͬ�ѵ��ڵģ����ṩ�µ�һ�������ϵ���Ч�Ͷ���Ƹ�ã���ͬ��

����3��ס�������仯�ģ��谴��ס��֤�������Ҫ���ṩ֤�����ϡ�

4����Ů����16����Ļ����ṩѧУ�ڶ�֤����

 

Best Regards

              Iceneed Fan
-------------------------

' 86 21 69902161
7 86 21 69902165
*  <mailto:fan.jing@shixintech.com��> fan.jing@shixintech.com
*  <http://www.shixintech.com> http://www.shixintech.com
";

        /// <summary>
        /// �����ַ�������
        /// </summary>
        public const string SECRET = "kjhqjherqiheramnxsaskjjkhqewurhbdnbaqjdquermqerjqnerkqelkjdqejhefjqfeqwfrqdjmqjejfndewffheqwkhbgeqwdeqwdxeqwdhbeqwdjqwdkjheqwjfhdjeqwhfbjwfkbeqwhbdvhgftwgdiurbdqliyh";
        public const string SECRETLOGIN = "nrewjnfrnfgrewjnw";
        
        private static readonly ResourceManager _resourceManager = new ResourceManager("SEP.HRMIS.Bll.ExceptionResources", typeof(ExceptionResources).Assembly);

        /// <summary>
        /// ����resourceId��ȡָ�����ַ�������
        /// </summary>
        public static string GetResourceMessage(string resourceId)
        {
            string retValue;
            try
            {
                retValue = _resourceManager.GetString(resourceId);
            }
            catch
            {
                retValue = BllExceptionConst._NormalError;
            }
            return retValue;
        }

        public static void ThrowException(string resourceId)
        {
            throw new ApplicationException(GetResourceMessage(resourceId));
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="strSrc">ԭ�ַ���</param>
        /// <param name="constSecret">�����ַ���</param>
        /// <returns></returns>
        public static string SimpleEncode(string strSrc, string constSecret)
        {
            char[] cnB = constSecret.ToCharArray(0, constSecret.Length);
            char[] show = strSrc.ToCharArray(0, strSrc.Length);
            StringBuilder str = new StringBuilder();
            //string str = "";
            for (int i = 0; i < show.Length; i++)
            {
                int sum = Convert.ToInt32(cnB[i]) + Convert.ToInt32(show[i]);
                string s;
                if (sum < 100 && sum >= 10)
                    s = "0" + sum;
                else if (sum < 10)
                    s = "00" + sum;
                else s = sum.ToString();
                str.Append(s);
                //str = str + s;
            }
            return str.ToString();
        }

        public static string SimpleDecode(string result, string constSecret)
        {
            char[] cnB = constSecret.ToCharArray(0, constSecret.Length);
            char[] rB = result.ToCharArray(0, result.Length);
            StringBuilder str = new StringBuilder();
            //string str = "";
            for (int i = 0; i < rB.Length; i += 3)
            {
                string s2 = result.Substring(i, 3);
                int sum = Convert.ToInt32(s2);
                char src = Convert.ToChar(sum - Convert.ToInt32(cnB[i / 3]));
                string s = src.ToString();
                str.Append(s);
                //str = str + s;
            }
            return str.ToString();
        }

        /// <summary>
        /// ȡ�ü����ַ���
        /// </summary>
        /// <param name="oldStr">ԭ�����ַ���</param>
        /// <param name="count">���ƴ���</param>
        /// <returns>�¼����ַ���</returns>
        public static string getExpandString(string oldStr, int count)
        {
            //string newStr = string.Empty;
            StringBuilder newStr = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                newStr.Append(oldStr);
                //newStr += oldStr;
            }
            return newStr.ToString();
        }

        /// <summary>
        /// �����˺�ID��ȡEmail��ַ
        /// </summary>
        public static List<List<string>> GetEmailsByAccountIds(List<Account> accounts)
        {
            List<List<string>> emails = new List<List<string>>();

            List<string> email1s = new List<string>();
            List<string> email2s = new List<string>();
            emails.Add(email1s);
            emails.Add(email2s);

            if (accounts == null || accounts.Count == 0)
                return emails;

            Account temp;
            foreach (Account account in accounts)
            {
                temp = BllInstance.AccountBllInstance.GetAccountById(account.Id);
                if (temp == null)
                    continue;

                if (!String.IsNullOrEmpty(temp.Email1))
                    email1s.Add(temp.Email1);
                if (!String.IsNullOrEmpty(temp.Email2))
                    email2s.Add(temp.Email2);
            }
            return emails;
        }
    }
}
